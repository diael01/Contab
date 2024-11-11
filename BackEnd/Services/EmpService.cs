using AutoMapper;
using Contracts.Interfaces.Services;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Services
{
    public class EmpService : IEmpService
    {
        ContabContext DBContext { get; set; }
        private readonly IMapper Mapper;

        public EmpService(ContabContext ctx, IMapper map)
        {
            DBContext = ctx;
            Mapper = map;
        }

        public async Task<IEnumerable<EmpDTO>> GetEmployeesByLevel(int level)
        {
            var list = await DBContext.Employees.Where(e => e.EmpNode.GetLevel() == level).ToListAsync();
            //todo: retrieve the parent for easy query
            var dtoList = Mapper.Map<IEnumerable<EmpDTO>>(list);
            return dtoList;
        }

        public async Task<EmpDTO> GetEmployeeById(string id)
        {
            var nodeId = HierarchyId.Parse(id);
            var nodeOrg = await DBContext.Employees.Where(e => e.EmpNode == nodeId).FirstOrDefaultAsync();
            var nodeDTO = Mapper.Map<EmpDTO>(nodeOrg);
            return nodeDTO;
        }

        public async Task<string> AddEmployee(EmpDTO emp)
        {
            var empdb = Mapper.Map<Employee>(emp);
            new EmpDTOValidator().ValidateAndThrow(emp);

            //set the function node based on the Text which was retrieved from DB based on the name
            //empdb.EmpFunctionNode = HierarchyId.Parse(emp.EmpFunctionNodeAsText);
            //set the manager node: if is null then the manager is the utmost top leve ie CEO
            if (string.IsNullOrEmpty(emp.ManagerNodeAsText) ||
                string.IsNullOrWhiteSpace(emp.ManagerNodeAsText))
            {
                empdb.EmpNode = empdb.ManagerNode = HierarchyId.GetRoot();
            } else //if is not top level, get the manager also from same EMployee table
            {
                HierarchyId node = await GetManagerNodeFromDB(emp);
                empdb.ManagerNode = node;
                if (node != null)
                {
                    var lastChild = DBContext.Employees.Where(e => e.EmpNode.GetAncestor(1) == node).Max(e => e.EmpNode);
                    if (lastChild != null)
                        empdb.EmpNode = node!.GetDescendant(lastChild, null);
                    else
                        empdb.EmpNode = node!.GetDescendant(null, null);
                } else return null;

            }
            empdb.EmpNodeAsText = empdb.EmpNode.ToString();
            empdb.CreatedAt = DateTime.Now;
            empdb.CreatedBy = "system";
            empdb.UpdatedAt = DateTime.Now;
            empdb.UpdatedBy = "system";
            new EmpValidator().ValidateAndThrow(empdb);

            await DBContext.AddAsync(empdb);
            await DBContext.SaveChangesAsync();

            return empdb.EmpNodeAsText;
        }

        public async Task<string> UpdateEmployee(EmpDTO empdto)
        {
            var node = await GetNodeFromDB(empdto);
            var emp = Mapper.Map<Employee>(empdto);

            //node.ManagerNode = HierarchyId.Parse(emp.ManagerNodeAsText);
            //node.EmpFunctionNode = HierarchyId.Parse(emp.EmpFunctionNodeAsText);


            node!.Name = emp.Name;
            node.Location = emp.Location;
            node.Surname = emp.Surname;
            node.EmpLevel = emp.EmpLevel;
            node.UpdatedAt = DateTime.Now;
            node.UpdatedBy = "system";
            new EmpValidator().ValidateAndThrow(node);
            DBContext.Entry(node).State = EntityState.Modified;
            await DBContext.SaveChangesAsync();
            return node.EmpNode.ToString();
        }

        public async Task DeleteEmployee(string nodeId)
        {
            if (!string.IsNullOrEmpty(nodeId))
            {
                var id = HierarchyId.Parse(nodeId);
                var node = await DBContext.Employees.Where(e => e.EmpNode == id).FirstOrDefaultAsync();
                if (node != null)
                {
                    DBContext.Entry(node).State = EntityState.Deleted;
                    await DBContext.SaveChangesAsync();
                }
            }
        }


        private async Task<HierarchyId> GetManagerNodeFromDB(EmpDTO emp)
        {
            HierarchyId node = null;
            if (!string.IsNullOrEmpty(emp.ManagerNodeAsText))
                node = HierarchyId.Parse(emp.ManagerNodeAsText);
            else
            {
                //search the node via name
                Employee obj = await DBContext.Employees.Where(e => (e.EmpNode == HierarchyId.Parse(emp.EmpNodeAsText))
                                                                    || (e.Name == emp.EmpNodeAsName)).FirstOrDefaultAsync();
                if (obj != null)
                    return obj.ManagerNode;
                else
                {
                    obj = await DBContext.Employees.Where(e => (e.Name == emp.EmpNodeAsName)).FirstOrDefaultAsync();
                    if (obj != null)
                        return obj.ManagerNode;
                    else
                        node = HierarchyId.GetRoot();
                }
            }
            return node;
        }

        private async Task<Employee> GetNodeFromDB(EmpDTO emp)
        {
            var obj = await DBContext.Employees.Where(e => e.EmpNode == HierarchyId.Parse(emp.EmpNodeAsText)).FirstOrDefaultAsync();
            if (obj == null)
                obj = await DBContext.Employees.Where(e => String.Equals(e.Name.ToUpper(), emp.Name.ToUpper())).FirstOrDefaultAsync();
            return obj;
        }
    }
}
