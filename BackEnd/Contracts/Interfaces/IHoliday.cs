using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IHoliday
    {
        Task<IEnumerable<Holiday>> GetAllAsync();
        Task<Holiday> GetByIdAsync(int id);
        Task AddAsync(Holiday holiday);
        Task UpdateAsync(Holiday holiday);
        Task DeleteAsync(int id);
    }


    public interface IHolidayRepository : IHoliday
    {
    }

    public interface IHolidayService : IHoliday
    {
    }
}
