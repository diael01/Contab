using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IEmp
    {
        Task<IEnumerable<EmpDTO>> GetEmployeesByLevel(int level);

        Task<EmpDTO> GetEmployeeById(string id);

        Task<EmpDTO> GetEmployeeByNode(string id);

        Task<EmpDTO> GetEmployeeByLastName(string id);

        Task<string> AddEmployee(EmpDTO pers);

        Task<string> UpdateEmployee(EmpDTO pers);

        Task DeleteEmployee(string orgId);
    }

    public interface IEmpRepository : IEmp
    {
    }

    public interface IEmpService : IEmp
    {
    }
}
