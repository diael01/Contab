using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IParam
    {
        Task<IEnumerable<Param>> GetAllAsync();
        Task<Param> GetByIdAsync(short id);
        Task AddAsync(Param param);
        Task UpdateAsync(Param param);
        Task DeleteAsync(short id);
    }


    public interface IParamRepository : IParam
    {
    }

    public interface IParamService : IParam
    {
    }
}