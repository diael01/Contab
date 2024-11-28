using Repository.Models;

namespace Contracts.Interfaces.Services
{
    public interface IParamService
    {
        Task<IEnumerable<Param>> GetParams();
        Task<Param> GetParam(short id);
        Task<Param> AddParam(Param param);
        Task<Param> UpdateParam(Param param);
        Task<Param> DeleteParam(short id);

    }
}