using Repository.Models;

namespace Repository.Interfaces
{

    public interface IParamRepository
    {
        Task<IEnumerable<Param>> GetParams();
        Task<Param> GetParam(short id);
        Task<Param> AddParam(Param param);
        Task<Param> UpdateParam(Param param);
        Task<Param> DeleteParam(short id);
    }
}
