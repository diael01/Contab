using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;

namespace Services
{

    public class ParamService : IParamService
    {
        private readonly IParamRepository _repository;
        public ParamService(IParamRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Param>> GetParams()
        {
            return await _repository.GetParams();
        }
        public async Task<Param> GetParam(short id)
        {
            return await _repository.GetParam(id);
        }
        public async Task<Param> AddParam(Param param)
        {
            return await _repository.AddParam(param);
        }
        public async Task<Param> UpdateParam(Param param)
        {
            return await _repository.UpdateParam(param);
        }
        public async Task<Param> DeleteParam(short id)
        {
            return await _repository.DeleteParam(id);
        }
    }
}
