using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IOrg
    {
        Task<IEnumerable<OrgDTO>> GetNodes(int level);

        Task<OrgDTO> GetNodeById(string id);

        Task<string> AddNode(OrgDTO org);

        Task<string> UpdateNode(OrgDTO org);

        Task DeleteNode(string orgId);
    }

    public interface IOrgRepository : IOrg
    {
    }

    public interface IOrgService : IOrg
    {
    }
}
