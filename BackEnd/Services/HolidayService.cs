using Contracts.Interfaces.Services;
using Repository.Interfaces;
using Repository.Models;

namespace Services
{

    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _repository;
        public HolidayService(IHolidayRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Holiday>> GetHolidays()
        {
            return await _repository.GetHolidays();
        }
        public async Task<Holiday> GetHoliday(int id)
        {
            return await _repository.GetHoliday(id);
        }
        public async Task<Holiday> AddHoliday(Holiday holiday)
        {
            return await _repository.AddHoliday(holiday);
        }
        public async Task<Holiday> UpdateHoliday(Holiday holiday)
        {
            return await _repository.UpdateHoliday(holiday);
        }
        public async Task<Holiday> DeleteHoliday(int id)
        {
            return await _repository.DeleteHoliday(id);
        }
    }

}
