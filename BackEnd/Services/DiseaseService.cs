using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;

namespace Services
{

    public class DiseaseService : IDiseaseService
    {
        private readonly IDiseaseRepository _repository;
        public DiseaseService(IDiseaseRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Disease>> GetDiseases()
        {
            return await _repository.GetDiseases();
        }
        public async Task<Disease> GetDisease(int id)
        {
            return await _repository.GetDisease(id);
        }
        public async Task<Disease> AddDisease(Disease disease)
        {
            return await _repository.AddDisease(disease);
        }
        public async Task<Disease> UpdateDisease(Disease disease)
        {
            return await _repository.UpdateDisease(disease);
        }
        public async Task<Disease> DeleteDisease(int id)
        {
            return await _repository.DeleteDisease(id);
        }

    }
}
