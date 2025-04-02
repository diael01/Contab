using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Impl
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly ContabContext _context;

        public HolidayRepository(ContabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Holiday>> GetAllAsync()
        {
            //return await _context.Holidays.ToListAsync();
            return await EfExtensions.ToListAsyncSafe<Holiday>(_context.Holidays.AsQueryable());
        }

        public async Task<Holiday> GetByIdAsync(int id)
        {
            return await _context.Holidays.FindAsync(id);
        }

        public async Task AddAsync(Holiday holiday)
        {
            await _context.Holidays.AddAsync(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Holiday holiday)
        {
            _context.Holidays.Update(holiday);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday != null)
            {
                _context.Holidays.Remove(holiday);
                await _context.SaveChangesAsync();
            }
        }
    }

}
