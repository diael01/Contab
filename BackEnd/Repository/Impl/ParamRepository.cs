using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Repository.Impl
{
    public class ParamRepository : IParamRepository
    {
        private readonly ContabContext _context;

        public ParamRepository(ContabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Param>> GetAllAsync()
        {
            var result = _context.Params;
            return await EfExtensions.ToListAsyncSafe<Param>(result.AsQueryable());
        }

        public async Task<Param> GetByIdAsync(int id)
        {
            return await _context.Params.FindAsync(id);
        }

        public async Task<int> AddAsync(Param param)
        {
            new ParamValidator().ValidateAndThrow(param);
            await _context.Params.AddAsync(param);
            await _context.SaveChangesAsync();
            _context.Entry(param).GetDatabaseValues();
            return param.Id;
        }

        public async Task<int> UpdateAsync(Param param)
        {
            _context.Params.Update(param);
            await _context.SaveChangesAsync();
             _context.Entry(param).GetDatabaseValues();
            return param.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var param = await _context.Params.FindAsync(id);
            if (param != null)
            {
                _context.Params.Remove(param);
                await _context.SaveChangesAsync();
            }
        }
    }

}
