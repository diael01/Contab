using Contracts.Interfaces;
using Contracts.Models;
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

        public async Task<Param> GetByIdAsync(short id)
        {
            return await _context.Params.FindAsync(id);
        }

        public async Task AddAsync(Param param)
        {
            await _context.Params.AddAsync(param);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Param param)
        {
            _context.Params.Update(param);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(short id)
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
