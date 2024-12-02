using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Impl
{

    public class IncreaseCodeRepository : IIncreaseCodeRepository
    {
        private readonly ContabContext _context;

        public IncreaseCodeRepository(ContabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IncreaseCode>> GetAllAsync()
        {
            return await _context.IncreaseCodes.ToListAsync();
        }

        public async Task<IncreaseCode> GetByIdAsync(int id)
        {
            return await _context.IncreaseCodes.FindAsync(id);
        }

        public async Task AddAsync(IncreaseCode increaseCode)
        {
            await _context.IncreaseCodes.AddAsync(increaseCode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IncreaseCode increaseCode)
        {
            _context.IncreaseCodes.Update(increaseCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
