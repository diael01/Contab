using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Models.Enums;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Services
{

    public class OrgService : IOrgService
    {
        ContabContext DBContext { get; set; }
        private readonly IMapper Mapper;

        public OrgService(ContabContext ctx, IMapper map)
        {
            DBContext = ctx;
            Mapper = map;
        }

        public async Task<IEnumerable<OrgDTO>> GetNodes(int level)
        {
            var list = await DBContext.Organisations.Where(e => e.OrgNode.GetLevel() == level).ToListAsync();
            //todo: retrieve the parent for easy query
            var dtoList = Mapper.Map<IEnumerable<OrgDTO>>(list);
            return dtoList;
        }

        public async Task<OrgDTO> GetNodeById(string id)
        {
            var nodeId = HierarchyId.Parse(id);
            var nodeOrg = await DBContext.Organisations.Where(e => e.OrgNode == nodeId).FirstOrDefaultAsync();
            var nodeDTO = Mapper.Map<OrgDTO>(nodeOrg);
            return nodeDTO;
        }

        public async Task<string> AddNode(OrgDTO org)
        {
            var orgdb = Mapper.Map<Organisation>(org);
            switch (orgdb.Level)
            {
                case (int)NodeType.Company:
                    orgdb.OrgNode = HierarchyId.GetRoot();
                    break;
                case (int)NodeType.Department:
                case (int)NodeType.Activity:
                case (int)NodeType.Function:
                    var node = HierarchyId.Parse(org.ParentNodeText);
                    if (node != null)
                    {
                        var lastChild = DBContext.Organisations.Where(e => e.OrgNode.GetAncestor(1) == node).Max(e => e.OrgNode);
                        if (lastChild != null)
                            orgdb.OrgNode = node.GetDescendant(lastChild, null);
                        else
                            orgdb.OrgNode = node.GetDescendant(null, null);
                    }
                    break;
            }
            orgdb.CreatedAt = DateTime.Now;
            orgdb.CreatedBy = "system";
            orgdb.UpdatedAt = DateTime.Now;
            orgdb.UpdatedBy = "system";

            await DBContext.AddAsync(orgdb);
            await DBContext.SaveChangesAsync();

            return orgdb.OrgNode.ToString();
        }

        public async Task<string> UpdateNode(OrgDTO org)
        {
            var id = HierarchyId.Parse(org.OrgNodeText);
            var node = DBContext.Organisations.Where(e => e.OrgNode == id).FirstOrDefault();
            new OrgValidator().ValidateAndThrow(node!);
            node!.Name = org.Name;
            node.Location = org.Location;
            node.LongName = org.LongName;
            node.Level = org.Level;
            node.UpdatedAt = DateTime.Now;
            node.UpdatedBy = "system";
            DBContext.Entry(node).State = EntityState.Modified;
            await DBContext.SaveChangesAsync();
            return node.OrgNode.ToString();
        }

        public async Task DeleteNode(string nodeId)
        {
            var id = HierarchyId.Parse(nodeId);
            var node = DBContext.Organisations.Where(e => e.OrgNode == id).FirstOrDefault();
            if (node != null)
            {
                DBContext.Entry(node).State = EntityState.Deleted;
                //DBContext.Remove(node);
                //try
                //{
                await DBContext.SaveChangesAsync();
                //} catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            }
        }
    }
}