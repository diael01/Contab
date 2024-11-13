using Repository.Models;

namespace Contracts.Interfaces.Services
{
    public interface IDiseaseService
    {
        Task<IEnumerable<Disease>> GetDiseases();
        Task<Disease> GetDisease(int id);
        Task<Disease> AddDisease(Disease disease);
        Task<Disease> UpdateDisease(Disease disease);
        Task<Disease> DeleteDisease(int id);
    }
}