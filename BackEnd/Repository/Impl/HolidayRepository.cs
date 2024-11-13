using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Impl
{

    public class HolidayRepository : IHolidayRepository
    {
        private readonly ContabContext _context;
        public HolidayRepository(ContabContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            return await _context.Holidays.ToListAsync();
        }
        public async Task<Holiday> GetHoliday(int id)
        {
            return await _context.Holidays.FindAsync(id);
        }
        public async Task<Holiday> AddHoliday(Holiday holiday)
        {
            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();
            return holiday;
        }
        public async Task<Holiday> UpdateHoliday(Holiday holiday)
        {
            _context.Entry(holiday).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return holiday;
        }
        public async Task<Holiday> DeleteHoliday(int id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday != null)
            {
                _context.Holidays.Remove(holiday);
                await _context.SaveChangesAsync();
            }
            return holiday;
        }
    }
}
