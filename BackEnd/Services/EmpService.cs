using AutoMapper;
using Contracts.Interfaces;
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

        public async Task<IEnumerable<EmpDTO>> GetEmployees(int level)
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
            new EmpDTOValidator().ValidateAndThrow(emp);
            var empdb = Mapper.Map<Employee>(emp);
            empdb.EmpFunctionNode = HierarchyId.Parse(emp.EmpFunctionNodeText);
            if (string.IsNullOrEmpty(emp.ManagerNodeText) && string.IsNullOrEmpty(emp.ManagerNodeName)
                ||
                string.IsNullOrWhiteSpace(emp.ManagerNodeText) && string.IsNullOrWhiteSpace(emp.ManagerNodeName))
            {
                empdb.EmpNode = empdb.ManagerNode = HierarchyId.GetRoot();
            } else
            {
                HierarchyId node = GetManagerNodeFromDB(emp);
                empdb.ManagerNode = node;
                empdb.ManagerNodeText = node.ToString();
                if (node != null)
                {
                    var lastChild = DBContext.Employees.Where(e => e.EmpNode.GetAncestor(1) == node).Max(e => e.EmpNode);
                    if (lastChild != null)
                        empdb.EmpNode = node!.GetDescendant(lastChild, null);
                    else
                        empdb.EmpNode = node!.GetDescendant(null, null);
                } else return null;

            }
            empdb.EmpNodeText = empdb.EmpNode.ToString();
            empdb.CreatedAt = DateTime.Now;
            empdb.CreatedBy = "system";
            empdb.UpdatedAt = DateTime.Now;
            empdb.UpdatedBy = "system";
            new EmpValidator().ValidateAndThrow(empdb);

            await DBContext.AddAsync(empdb);
            await DBContext.SaveChangesAsync();

            return empdb.EmpNodeText;
        }

        public async Task<string> UpdateEmployee(EmpDTO empdto)
        {
            var node = GetNodeFromDB(empdto);
            var emp = Mapper.Map<Employee>(empdto);

            node.ManagerNode = HierarchyId.Parse(emp.ManagerNodeText);
            node.ManagerNodeText = emp.ManagerNodeText;
            node.ManagerNodeName = emp.ManagerNodeName;

            node.EmpFunctionNode = HierarchyId.Parse(emp.EmpFunctionNodeText);
            node.EmpFunctionNodeText = emp.EmpFunctionNodeText;
            node.EmpFunctionNodeName = emp.EmpFunctionNodeName;

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
                var node = DBContext.Employees.Where(e => e.EmpNode == id).FirstOrDefault();
                if (node != null)
                {
                    DBContext.Entry(node).State = EntityState.Deleted;
                    await DBContext.SaveChangesAsync();
                }
            }
        }

        private HierarchyId GetManagerNodeFromDB(EmpDTO emp)
        {
            HierarchyId node = null;
            if (!string.IsNullOrEmpty(emp.ManagerNodeText))
                node = HierarchyId.Parse(emp.ManagerNodeText);
            else
            {
                //search the node via name
                var obj = DBContext.Employees.Where(e => String.Equals(e.Name.ToUpper(), emp.ManagerNodeName.ToUpper())).FirstOrDefault();
                if (obj != null)
                    node = obj.ManagerNode;
                else
                    node = HierarchyId.GetRoot();
            }
            return node;
        }

        private Employee GetNodeFromDB(EmpDTO emp)
        {
            var obj = DBContext.Employees.Where(e => e.EmpNode.ToString() == emp.EmpNodeText).FirstOrDefault();
            if (obj == null)
                obj = DBContext.Employees.Where(e => String.Equals(e.Name.ToUpper(), emp.Name.ToUpper())).FirstOrDefault();
            return obj;
        }
    }
}
