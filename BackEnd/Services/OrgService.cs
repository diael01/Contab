using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
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
            if (string.IsNullOrEmpty(org.ParentNodeText) || string.IsNullOrWhiteSpace(org.ParentNodeText))
                orgdb.OrgNode = HierarchyId.GetRoot();
            else
            {
                var node = HierarchyId.Parse(org.ParentNodeText);
                orgdb.ParentNode = node;
                if (node != null)
                {
                    var lastChild = DBContext.Organisations.Where(e => e.OrgNode.GetAncestor(1) == node).Max(e => e.OrgNode);
                    if (lastChild != null)
                        orgdb.OrgNode = node.GetDescendant(lastChild, null);
                    else
                        orgdb.OrgNode = node.GetDescendant(null, null);
                }
            }
            orgdb.OrgNodeText = orgdb.OrgNode.ToString();
            orgdb.CreatedAt = DateTime.Now;
            orgdb.CreatedBy = "system";
            orgdb.UpdatedAt = DateTime.Now;
            orgdb.UpdatedBy = "system";

            await DBContext.AddAsync(orgdb);
            await DBContext.SaveChangesAsync();

            return orgdb.OrgNodeText;
        }

        public async Task<string> UpdateNode(OrgDTO org)
        {
            var id = HierarchyId.Parse(org.OrgNodeText);
            var node = DBContext.Organisations.Where(e => e.OrgNode == id).FirstOrDefault();
            new OrgValidator().ValidateAndThrow(node!);
            node!.Name = org.Name;
            node.Location = org.Location;
            node.LongName = org.LongName;
            node.OrgLevel = org.OrgLevel;
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
                await DBContext.SaveChangesAsync();

            }
        }
    }
}