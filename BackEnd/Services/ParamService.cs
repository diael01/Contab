using AutoMapper;
using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ParamService : IParamService
    {
        private readonly IParamRepository _repository;
        private readonly IMapper Mapper;

        public ParamService(IParamRepository repository,IMapper map)
        {
            _repository = repository;
            Mapper = map;
        }

        public async Task<IEnumerable<Param>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Param> GetByIdAsync(short id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(ParamDTO dto)
        {
             var param = Mapper.Map<Param>(dto);
             param.CreatedAt = param.UpdatedAt = DateTime.Now;
             param.CreatedBy = param.UpdatedBy = "system";
             new ParamValidator().ValidateAndThrow(param);   
             await _repository.AddAsync(param);
        }

        public async Task UpdateAsync(ParamDTO dto)
        {
             var param = Mapper.Map<Param>(dto);
            new ParamValidator().ValidateAndThrow(param);   
            await _repository.UpdateAsync(param);
        }

        public async Task DeleteAsync(short id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
