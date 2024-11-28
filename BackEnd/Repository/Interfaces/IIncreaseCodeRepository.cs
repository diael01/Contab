using Repository.Models;

namespace Repository.Interfaces
{

    public interface IIncreaseCodeRepository
    {
        Task<IEnumerable<IncreaseCode>> GetAll();
        Task<IncreaseCode> GetById(int id);
        Task<IncreaseCode> Create(IncreaseCode increaseCode);
        Task Update(IncreaseCode increaseCode);
        Task Delete(int id);
    }

}
