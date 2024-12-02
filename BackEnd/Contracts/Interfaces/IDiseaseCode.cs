using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IDiseaseCode
    {
        Task<IEnumerable<DiseaseCode>> GetAllAsync();
        Task<DiseaseCode> GetByIdAsync(int id);
        Task AddAsync(DiseaseCode diseaseCode);
        Task UpdateAsync(DiseaseCode diseaseCode);
        Task DeleteAsync(int id);
    }


    public interface IDiseaseCodeRepository : IDiseaseCode
    {
    }

    public interface IDiseaseCodeService : IDiseaseCode
    {
    }
}