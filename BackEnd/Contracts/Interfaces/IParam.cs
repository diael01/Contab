using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IParam
    {
        Task<IEnumerable<Param>> GetAllAsync();
        Task<Param> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }

    public interface IParamRepository : IParam
    {
        Task<int> AddAsync(Param param);
        Task<int> UpdateAsync(Param param);
    }

    public interface IParamService : IParam
    {
        Task<int> AddAsync(ParamDTO param);
        Task<int> UpdateAsync(ParamDTO param);
    }
}