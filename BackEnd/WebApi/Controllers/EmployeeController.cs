using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class EmployeeController
    {
        // [Route("api/v1/[controller]")]
        [Route("/api/v1/Employee")]
        [ApiController]
        public class PersonalController : ControllerBase
        {
            IEmpService EmployeeService;
            public PersonalController(IEmpService os)
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
            public async Task<IActionResult> AddNode([FromBody] EmpDTO emp)
            {
                //validate

                new EmpDTOValidator().ValidateAndThrow(emp);
                var id = await EmployeeService.AddEmployee(emp);
                return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);
            }

            //PUT api/<EmployeeController>/5
            //[HttpPut("{id}")]
            [HttpPut]
            [Route("UpdateEmployee")]
            public async Task<IActionResult> UpdateNode([FromBody] EmpDTO emp)
            {
                //validate
                new EmpDTOValidator().ValidateAndThrow(emp);
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

            [HttpGet]
            [Route("GetEmployees")]
            public async Task<IActionResult> GetEmployees()
            {
                var emps = await EmployeeService.GetEmployees(0);
                return Ok(emps);
            }

            [HttpGet]
            [Route("GetEmployeesByLevel")]
            public async Task<IActionResult> GetEmployeesByLevel(int level)
            {
                var emps = await EmployeeService.GetEmployees(level);
                return Ok(emps);
            }

        }

    }
}
