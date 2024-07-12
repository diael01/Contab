using Contracts.Interfaces;
using Contracts.Models;
using Contracts.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    // [Route("api/v1/[controller]")]
    [Route("/api/v1/Org")]
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
        {
            var node = await OrgService.GetNodeById(nodeId);
            return node;
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

        // PUT api/<OrganisationController>/5
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

        // DELETE api/<OrganisationController>/5
        [HttpDelete("{id}")]
        [Route("DeleteNode")]
        public async Task<IActionResult> DeleteNode(string nodeId)
        {
            //validate
            try
            {
                await OrgService.DeleteNode(nodeId);
                return Ok();
            } catch (Exception ex)
            {
                return Problem(Constants.ContabError);
            }
        }

        [HttpGet]
        [Route("GetOrganisations")]
        public async Task<IActionResult> GetOrganisations()
        {
            try
            {
                var orgs = await OrgService.GetNodes(0);
                var content = JsonContent.Create(orgs);
                return Ok(content);
            } catch (Exception ex)
            {
                return Problem(Constants.ContabError);
            }
        }

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var depts = await OrgService.GetNodes(1);
                return Ok(depts);
            } catch (Exception ex)
            {
                return Problem(Constants.ContabError);
            }
        }

        [HttpGet]
        [Route("GetActivities")]
        public async Task<IActionResult> GetActivities()
        {
            try
            {
                var acts = await OrgService.GetNodes(2);
                return Ok(acts);
            } catch (Exception ex)
            {
                return Problem(Constants.ContabError);
            }
}

        [HttpGet]
        [Route("GetFunctions")]
        public async Task<IActionResult> GetFunctions()
        {
            try
            {
                var fncs = await OrgService.GetNodes(3);
                return Ok(fncs);
            } catch (Exception ex)
            {
                return Problem(Constants.ContabError);
            }
        }
    }
}
