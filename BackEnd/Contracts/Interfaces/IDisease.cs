using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IDisease
    {
        Task<IEnumerable<Disease>> GetAllAsync();
        Task<Disease> GetByIdAsync(int id);
        Task AddAsync(Disease disease);
        Task UpdateAsync(Disease disease);
        Task DeleteAsync(int id);
    }


    public interface IDiseaseRepository : IDisease
    {
    }

    public interface IDiseaseService : IDisease
    {
    }
}