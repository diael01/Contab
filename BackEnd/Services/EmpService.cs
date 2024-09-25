using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Xml.Linq;
using Contracts.Validation;

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
            var empdb = Mapper.Map<Employee>(emp);
            new EmpValidator().ValidateAndThrow(empdb);
            if (string.IsNullOrEmpty(emp.ManagerNodeText) || string.IsNullOrWhiteSpace(emp.ManagerNodeText))
                empdb.EmpNode = HierarchyId.GetRoot();
            else
            {
                HierarchyId node = GetNodeFromDTO(emp);
                if (node != null)
                {
                    var lastChild = DBContext.Employees.Where(e => e.EmpNode.GetAncestor(1) == node).Max(e => e.EmpNode);
                    if (lastChild != null)
                        empdb.EmpNode = node!.GetDescendant(lastChild, null);
                    else
                        empdb.EmpNode = node!.GetDescendant(null, null);
                } 
                else return null;
                
            }
            empdb.ManagerNodeText = empdb.EmpNode.ToString();
            empdb.CreatedAt = DateTime.Now;
            empdb.CreatedBy = "system";
            empdb.UpdatedAt = DateTime.Now;
            empdb.UpdatedBy = "system";

            await DBContext.AddAsync(empdb);
            await DBContext.SaveChangesAsync();

            return empdb.EmpNodeText;
        }

        public async Task<string> UpdateEmployee(EmpDTO emp)
        {
            var id = GetNodeFromDTO(emp);
            var node = DBContext.Employees.Where(e => e.EmpNode == id).FirstOrDefault();
            //new OrgValidator().ValidateAndThrow(node!);
            node!.Name = emp.Name;
            node.Location = emp.Location;
            node.Surname = emp.Surname;
            node.EmpLevel = emp.EmpLevel;
            node.UpdatedAt = DateTime.Now;
            node.UpdatedBy = "system";
            DBContext.Entry(node).State = EntityState.Modified;
            await DBContext.SaveChangesAsync();
            return node.EmpNode.ToString();
        }

        public async Task DeleteEmployee(string nodeId)
        {
            var id = HierarchyId.Parse(nodeId);
            var node = DBContext.Employees.Where(e => e.EmpNode == id).FirstOrDefault();
            if (node != null)
            {
                DBContext.Entry(node).State = EntityState.Deleted;
                await DBContext.SaveChangesAsync();
            }
        }

        private HierarchyId GetNodeFromDTO(EmpDTO emp)
        {
            HierarchyId node;
            new EmpDTOValidator().ValidateAndThrow(emp);
            if (!string.IsNullOrEmpty(emp.ManagerNodeText))
                node = HierarchyId.Parse(emp.ManagerNodeText);
            else
            {
                //search the node via name
                var obj = DBContext.Employees.Where(e => e.Name == emp.ManagerNodeName).FirstOrDefault();
                if (obj != null)
                    node = obj.ManagerNode!;
                else
                    return null;
            }
            return node;
        }
 }
}
