using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IIncreaseCode
    {
        Task<IEnumerable<IncreaseCode>> GetAllAsync();
        Task<IncreaseCode> GetByIdAsync(int id);
        Task AddAsync(IncreaseCode increaseCode);
        Task UpdateAsync(IncreaseCode increaseCode);
        Task DeleteAsync(int id);
    }

    public interface IIncreaseCodeRepository : IIncreaseCode
    {
    }

    public interface IIncreaseCodeService : IIncreaseCode
    {
    }
}
