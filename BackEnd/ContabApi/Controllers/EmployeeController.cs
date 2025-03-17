using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//todo: refactor Organisation and Employee
namespace ContabApi.Controllers
{

    // [Route("api/v1/[controller]")]
    [Route("/api/v1/Emp")]
    [ApiController]
    //[Authorize(Roles = "admin")] //do not use roles, use claims and policies, a claim can be a role
    [Authorize(Policy = "fullaccess")] //for testing purpose
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class EmployeeController : ControllerBase
    {
        IEmp EmployeeService;
        IAuthorizationService Auth;
        public EmployeeController(IEmp os, IAuthorizationService auth)
        {
            EmployeeService = os;
            Auth = auth;
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById([FromQuery] string id)
        {
            //old way
            //do not use it coz it clutters the code,use instead POLICIES
            // var result = await Auth.AuthorizeAsync(User, "isadmin");
            // if (result.Succeeded)
            // {
            //return Ok(result);
            //or even this, do not use it like this
            //var claims = User.Claims;
            //var fullaccess = User.HasClaim(p => p.Type == "scope" && p.Value == "ContabApi_fullaccess");
            //var isAdmin = User.FindFirst(p => p.Type == JwtClaimTypes.Role && p.Value == "admin");

            var node = await EmployeeService.GetEmployeeById(id);
            new EmpDTOValidator().ValidateAndThrow(node);
            return Ok(node);
            //}
            //return Problem(JsonConvert.SerializeObject(result));
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
