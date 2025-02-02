using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContabApi.Controllers
{

    [Route("api/v1/disease")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _service;

        public DiseaseController(IDiseaseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Disease disease)
        {
            await _service.AddAsync(disease);
            return CreatedAtAction(nameof(Get), new { id = disease.Id }, disease);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Disease disease)
        {
            if (id != disease.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(disease);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }



}
