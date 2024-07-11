using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrgController : ControllerBase
    {
        IOrgService OrgService;
        public OrgController(IOrgService os)
        {
            OrgService = os;
        }

        [HttpGet]
        [Route("GetNodeById")]
        public async Task<OrgDTO> GetNodebyId(string nodeId)
        //public IEnumerable<string> Get()
        {
            var node = await OrgService.GetNodeById(nodeId);
            return node;
        }

        [HttpGet]
        [Route("GetOrganisations")]
        public async Task<IEnumerable<OrgDTO>> GetOrganisations()
        //public IEnumerable<string> Get()
        {
            var orgs = await OrgService.GetNodes(1);
            return orgs;
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IEnumerable<OrgDTO>> GetDepartments()
        {
            var depts = await OrgService.GetNodes(2);
            return depts;
        }

        [HttpGet]
        [Route("GetActivities")]
        public async Task<IEnumerable<OrgDTO>> GetActivities()
        {
            var acts = await OrgService.GetNodes(3);
            return acts;
        }

        [HttpGet]
        [Route("GetFunctions")]
        public async Task<IEnumerable<OrgDTO>> GetFunctions()
        {
            var fncs = await OrgService.GetNodes(4);
            return fncs;
        }

        // POST api/<OrganisationController>
        [HttpPost]
        [Route("AddNode")]
        public async Task<string> AddNode([FromBody] OrgDTO org)
        {
            //validate
            new NodeValidator().ValidateAndThrow(org);
            var nodeId = await OrgService.AddNode(org);
            return nodeId;
        }

        // PUT api/<OrganisationController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("UpdateNode")]
        public async Task<string> UpdateNode([FromBody] OrgDTO org)
        {
            //validate
            new NodeValidator().ValidateAndThrow(org);
            var nodeId = await OrgService.UpdateNode(org);
            return nodeId;
        }

        // DELETE api/<OrganisationController>/5
        [HttpDelete("{id}")]
        [Route("DeleteNode")]
        public async Task DeleteNode(string nodeId)
        {
            //validate
            await OrgService.DeleteNode(nodeId);
        }
    }
}
