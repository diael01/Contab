using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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
            var list = await DBContext.Organisations.Where(e => e.Node.GetLevel() == level).ToListAsync();
            //todo: retrieve the parent for easy query
            var dtoList = Mapper.Map<IEnumerable<OrgDTO>>(list);
            return dtoList;
        }

        public async Task<OrgDTO> GetNodeById(string id)
        {
            var nodeId = HierarchyId.Parse(id);
            var nodeOrg = await DBContext.Organisations.Where(e => e.Node == nodeId).FirstOrDefaultAsync();
            var nodeDTO = Mapper.Map<OrgDTO>(nodeOrg);
            return nodeDTO;
        }

        public async Task<string> AddNode(OrgDTO org)
        {
            var orgdb = Mapper.Map<Organisation>(org);
            if (string.IsNullOrEmpty(org.ParentNodeText) || string.IsNullOrWhiteSpace(org.ParentNodeText))
                orgdb.Node = HierarchyId.GetRoot();
            else
            {
                var node = await GetParentNodeFromDTO(org);
                if (node != null)
                {
                    var lastChild = DBContext.Organisations.Where(e => e.Node.GetAncestor(1) == node).Max(e => e.Node);
                    if (lastChild != null)
                        orgdb.Node = node.GetDescendant(lastChild, null);
                    else
                        orgdb.Node = node.GetDescendant(null, null);
                } else return null;
            }
            //orgdb.NodeText = orgdb.Node.ToString();
            if (!string.IsNullOrEmpty(org.ParentNodeText) && !string.IsNullOrWhiteSpace(org.ParentNodeText))
                orgdb.ParentNode = HierarchyId.Parse(org.ParentNodeText);
            orgdb.ParentNodeName = org.ParentNodeName;
            orgdb.NodeName = org.NodeName;
            orgdb.CreatedAt = DateTime.Now;
            orgdb.CreatedBy = "system";
            orgdb.UpdatedAt = DateTime.Now;
            orgdb.UpdatedBy = "system";
            new OrgValidator().ValidateAndThrow(orgdb);

            await DBContext.AddAsync(orgdb);
            await DBContext.SaveChangesAsync();

            return orgdb.Node.ToString();
        }

        public async Task<string> UpdateNode(OrgDTO org)
        {
            var id = HierarchyId.Parse(org.NodeText);
            Organisation node = await DBContext.Organisations.Where(e => e.Node == id).FirstOrDefaultAsync();
            new OrgValidator().ValidateAndThrow(node!);
            node!.NodeName = org.NodeName;
            node.Location = org.Location;
            node.NodeLevel = org.NodeLevel;
            node.UpdatedAt = DateTime.Now;
            node.UpdatedBy = "system";
            DBContext.Entry(node).State = EntityState.Modified;
            await DBContext.SaveChangesAsync();
            return node.Node.ToString();
        }

        public async Task DeleteNode(string nodeId)
        {
            var id = HierarchyId.Parse(nodeId);
            Organisation node = await DBContext.Organisations.Where(e => e.Node == id).FirstOrDefaultAsync();
            if (node != null)
            {
                DBContext.Entry(node).State = EntityState.Deleted;
                await DBContext.SaveChangesAsync();

            }
        }

        private async Task<HierarchyId> GetParentNodeFromDTO(OrgDTO org)
        {
            HierarchyId node;
            new NodeValidator().ValidateAndThrow(org);
            if (!string.IsNullOrEmpty(org.ParentNodeText))
                node = HierarchyId.Parse(org.ParentNodeText);
            else
            {
                //search the node via name
                Organisation obj = await DBContext.Organisations.Where(e => e.Node == HierarchyId.Parse(org.NodeText)).FirstOrDefaultAsync();
                if (obj != null)
                    node = obj.ParentNode!;
                else
                {
                    obj = await DBContext.Organisations.Where(e => e.NodeName == org.NodeName).FirstOrDefaultAsync();
                    if (obj != null)
                        return obj.ParentNode;
                    else
                        return null;
                }
            }
            return node;
        }
    }
}