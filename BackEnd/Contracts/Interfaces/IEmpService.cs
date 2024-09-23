using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IEmpService
    {
        Task<IEnumerable<EmpDTO>> GetEmployees(int level);
        
        Task<EmpDTO> GetEmployeeById(string id);

        Task<string> AddEmployee(EmpDTO pers);

        Task<string> UpdateEmployee(EmpDTO pers);

        Task DeleteEmployee(string orgId);
    }
}
