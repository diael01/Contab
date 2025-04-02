using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IParam
    {
        Task<IEnumerable<Param>> GetAllAsync();
        Task<Param> GetByIdAsync(short id);
        Task DeleteAsync(short id);
    }

    public interface IParamRepository : IParam
    {
        Task AddAsync(Param param);
        Task UpdateAsync(Param param);
    }

    public interface IParamService : IParam
    {
        Task AddAsync(ParamDTO param);
        Task UpdateAsync(ParamDTO param);
    }
}