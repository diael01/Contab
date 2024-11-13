using Repository.Models;

namespace Repository.Interfaces
{
    public interface IDiseaseRepository
    {
        Task<IEnumerable<Disease>> GetDiseases();
        Task<Disease> GetDisease(int id);
        Task<Disease> AddDisease(Disease disease);
        Task<Disease> UpdateDisease(Disease disease);
        Task<Disease> DeleteDisease(int id);
    }
}
