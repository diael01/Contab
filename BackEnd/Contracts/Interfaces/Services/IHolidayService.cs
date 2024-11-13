using Repository.Models;

namespace Contracts.Interfaces.Services
{
    public interface IHolidayService
    {
        Task<IEnumerable<Holiday>> GetHolidays();
        Task<Holiday> GetHoliday(int id);
        Task<Holiday> AddHoliday(Holiday holiday);
        Task<Holiday> UpdateHoliday(Holiday holiday);
        Task<Holiday> DeleteHoliday(int id);
    }
}
