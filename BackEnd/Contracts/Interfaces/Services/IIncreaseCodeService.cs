using Repository.Models;

namespace Contracts.Interfaces.Services
{
    public interface IIncreaseCodeService
    {
        Task<IEnumerable<IncreaseCode>> GetAll();
        Task<IncreaseCode> GetById(int id);
        Task<IncreaseCode> Create(IncreaseCode increaseCode);
        Task Update(IncreaseCode increaseCode);
        Task Delete(int id);
    }
}
