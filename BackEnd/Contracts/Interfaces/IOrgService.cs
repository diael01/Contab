using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IOrgService
    {
        Task<IEnumerable<OrgDTO>> GetNodes(int level);

        Task<OrgDTO> GetNodeById(string id);

        Task<string> AddNode(OrgDTO org);

        Task<string> UpdateNode(OrgDTO org);

        Task DeleteNode(string orgId);
    }
}
