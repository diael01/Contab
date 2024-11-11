using Repository.Models;

namespace Repository.Interfaces
{
    public interface IBankRepository
    {
        Task<IEnumerable<Bank>> GetBanks();
        Task<Bank> GetBank(int id);
        Task<Bank> AddBank(Bank bank);
        Task<Bank> UpdateBank(Bank bank);
        Task<Bank> DeleteBank(int id);
    }
}
