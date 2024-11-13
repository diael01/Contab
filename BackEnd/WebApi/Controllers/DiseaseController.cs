using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseService _service;
        public DiseasesController(IDiseaseService service)
        {
            _service = service;
        }

        // GET: api/Diseases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDiseases()
        {
            return Ok(await _service.GetDiseases());
        }

        // GET: api/Diseases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetDisease(int id)
        {
            var disease = await _service.GetDisease(id);
            if (disease == null)
            {
                return NotFound();
            }
            return Ok(disease);
        }

        // POST: api/Diseases
        [HttpPost]
        public async Task<ActionResult<Disease>> AddDisease(Disease disease)
        {
            var newDisease = await _service.AddDisease(disease);
            return CreatedAtAction(nameof(GetDisease), new { id = newDisease.Id }, newDisease);
        }

        // PUT: api/Diseases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDisease(int id, Disease disease)
        {

            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/2
            if (id != disease.Id)
            {
                return BadRequest();
            }
            await _service.UpdateDisease(disease);
            return NoContent();
        }

        // DELETE: api/Diseases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisease(int id)
        {
            await _service.DeleteDisease(id);
            return NoContent();
        }
    }
}
