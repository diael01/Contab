using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Utils;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task<EmpDTO> GetEmployeeByNode(string id)
        {
            var nodeId = HierarchyId.Parse(id);
            var nodeOrg = await DBContext.Employees.Where(e => e.EmpNode == nodeId).FirstOrDefaultAsync();
            var nodeDTO = Mapper.Map<EmpDTO>(nodeOrg);
            return nodeDTO;
        }

        public async Task<EmpDTO> GetEmployeeById(string node)
        {

            var nodeOrg = await DBContext.Employees.Where(e => e.EmpNode == HierarchyId.Parse(node)).FirstOrDefaultAsync();
            var nodeDTO = Mapper.Map<EmpDTO>(nodeOrg);
            return nodeDTO;
        }

        public async Task<EmpDTO> GetEmployeeByLastName(string lastName)
        {
            var emp = await DBContext.Employees.Where(e => e.LastName.ToUpper().Equals(lastName.ToUpper())).FirstOrDefaultAsync();
            var empDTO = Mapper.Map<EmpDTO>(emp);
            return empDTO;
        }

        public async Task<string> AddEmployee(EmpDTO emp)
        {
            var empdb = Mapper.Map<Employee>(emp);
            new EmpDTOValidator().ValidateAndThrow(emp);

            //set the function node based on the Text which was retrieved from DB based on the name
            //empdb.EmpFunctionNode = HierarchyId.Parse(emp.EmpFunctionNodeAsText);
            //set the manager node: if is null then the manager is the utmost top leve ie CEO
            if (string.IsNullOrEmpty(emp.ManagerNodeText) ||
                string.IsNullOrWhiteSpace(emp.ManagerNodeText))
            {
                empdb.EmpNode = empdb.ManagerNode = HierarchyId.GetRoot();
            } else //if is not top level, get the manager also from same EMployee table
            {
                HierarchyId node = await GetManagerNode(emp);
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
            //validate empdto => the fullname shant be null or white or empty
            var node = await GetNodeFromDB(empdto);
            var emp = Mapper.Map<Employee>(empdto);

            if (node != null)
            {
                //clone the employee
                //var serialized = JsonConvert.SerializeObject(emp);
                //var node1 = JsonConvert.DeserializeObject<Employee>(serialized);
                //node1.EmpNode = HierarchyId.Parse(empdto.EmpNodeText);
                //node1.ManagerNode = HierarchyId.Parse(empdto.ManagerNodeText);
                //node1.UpdatedAt = DateTime.Now;
                //node1.UpdatedBy = "system";
                //new EmpValidator().ValidateAndThrow(node1);
                //DBContext.Entry(node1).State = EntityState.Modified;
                //try
                //{
                //    await DBContext.SaveChangesAsync();
                //} catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                //return node1.EmpNode.ToString();
                //todo: use cloning lib for all fields
                node.LastName = emp.LastName;

                node.UpdatedAt = DateTime.Now;
                node.UpdatedBy = "system";
                new EmpValidator().ValidateAndThrow(node);
                DBContext.Entry(node).State = EntityState.Modified;
                try
                {
                    await DBContext.SaveChangesAsync();
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return node.EmpNode.ToString();
            }
            return null;
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

        private async Task<HierarchyId> GetManagerNode(EmpDTO emp)
        {
            HierarchyId node = null;
            if (!string.IsNullOrEmpty(emp.ManagerNodeText))
                node = HierarchyId.Parse(emp.ManagerNodeText);
            else
            {
                //search the node via name
                Employee obj = await DBContext.Employees.Where(e => e.EmpNode == HierarchyId.Parse(emp.EmpNodeText)).FirstOrDefaultAsync();
                //todo? what is EmpNodeAsName
                if (obj != null)
                    return obj.ManagerNode;
                else
                {
                    obj = await DBContext.Employees.Where(e => e.LastName == Utils.GetEmployeeLastNameUpper(emp.LastName)).FirstOrDefaultAsync();
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
            var obj = await DBContext.Employees.Where(e => e.EmpNode == HierarchyId.Parse(emp.EmpNodeText)).FirstOrDefaultAsync();
            if (obj == null)
                obj = await DBContext.Employees.Where(e => String.Equals(e.LastName.ToUpper(), Utils.GetEmployeeLastNameUpper(emp.LastName))).FirstOrDefaultAsync();
            return obj;
        }
    }
}
