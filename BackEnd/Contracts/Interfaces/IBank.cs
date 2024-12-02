using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IBank
    {
        Task<IEnumerable<Bank>> GetAllAsync();
        Task<Bank> GetByIdAsync(int id);
        Task AddAsync(Bank bank);
        Task UpdateAsync(Bank bank);
        Task DeleteAsync(int id);
    }

    public interface IBankRepository : IBank
    {
    }

    public interface IBankService : IBank
    {
    }
}
