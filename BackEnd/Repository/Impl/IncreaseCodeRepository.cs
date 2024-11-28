using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{

    public class IncreaseCodeRepository : IIncreaseCodeRepository
    {
        private readonly ContabContext _context;
        public IncreaseCodeRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<IncreaseCode>> GetAll()
        {
            return await _context.IncreaseCodes.ToListAsync();
        }
        public async Task<IncreaseCode> GetById(int id)
        {
            return await _context.IncreaseCodes.FindAsync(id);
        }
        public async Task<IncreaseCode> Create(IncreaseCode increaseCode)
        {
            _context.IncreaseCodes.Add(increaseCode);
            await _context.SaveChangesAsync();
            return increaseCode;
        }
        public async Task Update(IncreaseCode increaseCode)
        {
            _context.Entry(increaseCode).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var increaseCode = await _context.IncreaseCodes.FindAsync(id);
            if (increaseCode != null)
            {
                _context.IncreaseCodes.Remove(increaseCode);
                await _context.SaveChangesAsync();
            }
        }
    }
}
