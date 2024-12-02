using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{

    public class DiseaseCodeService : IDiseaseCodeService
    {
        private readonly IDiseaseCodeRepository _repository;

        public DiseaseCodeService(IDiseaseCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DiseaseCode>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DiseaseCode> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(DiseaseCode diseaseCode)
        {
            await _repository.AddAsync(diseaseCode);
        }

        public async Task UpdateAsync(DiseaseCode diseaseCode)
        {
            await _repository.UpdateAsync(diseaseCode);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
