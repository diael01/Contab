using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{
    public class IncreaseCodeService : IIncreaseCodeService
    {
        private readonly IIncreaseCodeRepository _repository;

        public IncreaseCodeService(IIncreaseCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IncreaseCode>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IncreaseCode> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(IncreaseCode increaseCode)
        {
            await _repository.AddAsync(increaseCode);
        }

        public async Task UpdateAsync(IncreaseCode increaseCode)
        {
            await _repository.UpdateAsync(increaseCode);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
