using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{
    public class ParamRepository : IParamRepository
    {
        private readonly ContabContext _context;
        public ParamRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Param>> GetParams()
        {
            return await _context.Params.ToListAsync();
        }
        public async Task<Param> GetParam(short id)
        {
            return await _context.Params.FindAsync(id);
        }
        public async Task<Param> AddParam(Param param)
        {
            _context.Params.Add(param);
            await _context.SaveChangesAsync();
            return param;
        }
        public async Task<Param> UpdateParam(Param param)
        {
            _context.Entry(param).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return param;
        }
        public async Task<Param> DeleteParam(short id)
        {
            var param = await _context.Params.FindAsync(id);
            if (param != null)
            {
                _context.Params.Remove(param);
                await _context.SaveChangesAsync();
            }
            return param;
        }

    }
}
