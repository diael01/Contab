using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{

    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _repository;

        public DiseaseService(IDiseaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Disease>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Disease> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Disease disease)
        {
            await _repository.AddAsync(disease);
        }

        public async Task UpdateAsync(Disease disease)
        {
            await _repository.UpdateAsync(disease);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
