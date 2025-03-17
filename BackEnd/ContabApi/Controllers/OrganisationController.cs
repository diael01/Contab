using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//todo: refactor Organisation and Employee
namespace ContabApi.Controllers
{
    [Route("/api/v1/Org")]
    [ApiController]
    //6. [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class OrgController : ControllerBase
    {
        IOrgService OrgService;
        public OrgController(IOrgService os)
        //todo: use factory to get the services, IRepositoryFactory repositoryFactory)
        {
            OrgService = os;
        }

        [HttpGet]
        [Route("GetNodeById")]
        public async Task<IActionResult> GetNodeById([FromQuery] string node)
        {
            var nodeDTO = await OrgService.GetNodeById(node);
            new NodeValidator().ValidateAndThrow(nodeDTO);
            return Ok(nodeDTO);
        }

        // POST api/<OrganisationController>
        [HttpPost]
        [Route("AddNode")]
        public async Task<IActionResult> AddNode([FromBody] OrgDTO org)
        {
            //validate
            //OrgDTO org = new OrgDTO();
            new NodeValidator().ValidateAndThrow(org);
            var id = await OrgService.AddNode(org);
            return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);
        }

        //PUT api/<OrganisationController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("UpdateNode")]
        public async Task<IActionResult> UpdateNode([FromBody] OrgDTO org)
        {
            //validate
            new NodeValidator().ValidateAndThrow(org);
            var id = await OrgService.UpdateNode(org);
            return !String.IsNullOrWhiteSpace(id) ? Ok(id) : Problem(Constants.ContabError);

        }

        //// DELETE api/<OrganisationController>/5
        [HttpDelete]
        [Route("DeleteNode")]
        public async Task<IActionResult> DeleteNode([FromQuery] string node)
        {
            await OrgService.DeleteNode(node);
            return Ok();
        }

        [HttpGet]
        [Route("GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            var orgs = await OrgService.GetNodes(0);
            //var content = JsonContent.Create(orgs);
            return Ok(orgs);
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var depts = await OrgService.GetNodes(1);
            return Ok(depts);
        }

        [HttpGet]
        [Route("GetActivities")]
        public async Task<IActionResult> GetActivities()
        {
            var acts = await OrgService.GetNodes(2);
            return Ok(acts);
        }

        [HttpGet]
        [Route("GetWorkTypes")]
        public async Task<IActionResult> GetWorkTypes()
        {
            var acts = await OrgService.GetNodes(3);
            return Ok(acts);
        }

        [HttpGet]
        [Route("GetFunctions")]
        public async Task<IActionResult> GetFunctions()
        {
            var fncs = await OrgService.GetNodes(4);
            return Ok(fncs);
        }
    }
}
