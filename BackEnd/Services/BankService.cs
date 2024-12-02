using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _repository;

        public BankService(IBankRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Bank> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Bank bank)
        {
            await _repository.AddAsync(bank);
        }

        public async Task UpdateAsync(Bank bank)
        {
            await _repository.UpdateAsync(bank);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
