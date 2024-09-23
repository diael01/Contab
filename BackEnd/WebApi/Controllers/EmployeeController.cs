using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
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
                //new EmpValidator().ValidateAndThrow(node);
                return Ok(node);
            }

            // POST api/<PersonalanisationController>
            [HttpPost]
            [Route("AddEmployee")]
            public async Task<IActionResult> AddNode([FromBody] EmpDTO emp)
            {
                //validate
               
                //new NodeValidator().ValidateAndThrow(emp);
                var id = await EmployeeService.AddEmployee(emp);
                return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);
            }

            //PUT api/<PersonalanisationController>/5
            //[HttpPut("{id}")]
            [HttpPut]
            [Route("UpdateEmployee")]
            public async Task<IActionResult> UpdateNode([FromBody] EmpDTO emp)
            {
                //validate
                //new NodeValidator().ValidateAndThrow(Personal);
                var id = await EmployeeService.UpdateEmployee(emp);
                return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);

            }

            //// DELETE api/<PersonalanisationController>/5
            [HttpDelete]
            [Route("DeleteEmployee")]
            public async Task<IActionResult> DeleteNode([FromQuery] string id)
            {
                await EmployeeService.DeleteEmployee(id);
                return Ok();
            }

            [HttpGet]
            [Route("GetEmployees")]
            public async Task<IActionResult> GetEmployees()
            {
                var Personals = await EmployeeService.GetEmployees(0);
                //var content = JsonContent.Create(Personals);
                return Ok(Personals);
            }

            //[HttpGet]
            //[Route("GetDepartments")]
            //public async Task<IActionResult> GetDepartments()
            //{
            //    var depts = await PersonalService.GetNodes(1);
            //    return Ok(depts);
            //}

            //[HttpGet]
            //[Route("GetActivities")]
            //public async Task<IActionResult> GetActivities()
            //{
            //    var acts = await PersonalService.GetNodes(2);
            //    return Ok(acts);
            //}

            //[HttpGet]
            //[Route("GetFunctions")]
            //public async Task<IActionResult> GetFunctions()
            //{
            //    var fncs = await PersonalService.GetNodes(3);
            //    return Ok(fncs);
            //}
        }

    }
}
