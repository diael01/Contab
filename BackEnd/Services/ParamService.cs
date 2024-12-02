using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{
    public class ParamService : IParamService
    {
        private readonly IParamRepository _repository;

        public ParamService(IParamRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Param>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Param> GetByIdAsync(short id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Param param)
        {
            await _repository.AddAsync(param);
        }

        public async Task UpdateAsync(Param param)
        {
            await _repository.UpdateAsync(param);
        }

        public async Task DeleteAsync(short id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
