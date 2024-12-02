using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/v1/discode")]
    [ApiController]
    public class DiseaseCodeController : ControllerBase
    {
        private readonly IDiseaseCodeService _service;

        public DiseaseCodeController(IDiseaseCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseCode>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseCode>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DiseaseCode diseaseCode)
        {
            await _service.AddAsync(diseaseCode);
            return CreatedAtAction(nameof(Get), new { id = diseaseCode.Id }, diseaseCode);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DiseaseCode diseaseCode)
        {
            if (id != diseaseCode.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(diseaseCode);
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
