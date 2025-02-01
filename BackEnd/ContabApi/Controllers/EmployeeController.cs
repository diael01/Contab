using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ContabApi.Controllers
{

    // [Route("api/v1/[controller]")]
    [Route("/api/v1/Emp")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class EmployeeController : ControllerBase
    {
        IEmp EmployeeService;
        public EmployeeController(IEmp os)
        {
            EmployeeService = os;
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] string id)
        {
            var node = await EmployeeService.GetEmployeeById(id);
            new EmpDTOValidator().ValidateAndThrow(node);
            return Ok(node);
        }

        // POST api/<employeeController>
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmpDTO emp)
        {
            //validate
            //
            var id = await EmployeeService.AddEmployee(emp);
            return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);
        }

        //PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmpDTO emp)
        {
            //validate
            //new EmpDTOValidator().ValidateAndThrow(emp);
            var id = await EmployeeService.UpdateEmployee(emp);
            return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);

        }

        //// DELETE api/<EmpController>/5
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] string id)
        {
            await EmployeeService.DeleteEmployee(id);
            return Ok();
        }

        //[HttpGet]
        //[Route("GetEmployees")]
        //public async Task<IActionResult> GetEmployees()
        //{
        //    var emps = await EmployeeService.GetEmployees(0);
        //                    //.Append<IEnumerable<EmpDTO>>(EmployeeService.GetEmployees(1))
        //                    //.Append(EmployeeService.GetEmployees(2));
        //    return Ok(emps);
        //}

        [HttpGet]
        [Route("GetEmployeesByLevel")]
        public async Task<IActionResult> GetEmployeesByLevel(int level)
        {
            var emps = await EmployeeService.GetEmployeesByLevel(level);
            return Ok(emps);
        }



    }

}
