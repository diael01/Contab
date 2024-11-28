using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;

namespace Services
{
    public class IncreaseCodeService : IIncreaseCodeService
    {
        private readonly IIncreaseCodeRepository _repository;
        public IncreaseCodeService(IIncreaseCodeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<IncreaseCode>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<IncreaseCode> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<IncreaseCode> Create(IncreaseCode increaseCode)
        {
            return await _repository.Create(increaseCode);
        }
        public async Task Update(IncreaseCode increaseCode)
        {
            await _repository.Update(increaseCode);
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
