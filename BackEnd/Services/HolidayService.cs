using Contracts.Interfaces;
using Contracts.Models;

namespace Services
{

    public class HolidayService : IHolidayService
    {
        private readonly IHolidayRepository _repository;

        public HolidayService(IHolidayRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Holiday>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Holiday> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Holiday holiday)
        {
            await _repository.AddAsync(holiday);
        }

        public async Task UpdateAsync(Holiday holiday)
        {
            await _repository.UpdateAsync(holiday);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
