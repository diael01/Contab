using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IEmpService
    {
        Task<IEnumerable<EmpDTO>> GetEmployeesByLevel(int level);

        Task<EmpDTO> GetEmployeeById(string id);

        Task<string> AddEmployee(EmpDTO pers);

        Task<string> UpdateEmployee(EmpDTO pers);

        Task DeleteEmployee(string orgId);
    }
}
