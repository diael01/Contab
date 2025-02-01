using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ContabApi.Controllers
{
    [Route("/api/v1/incode")]
    [ApiController]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class IncreaseCodeController : ControllerBase
    {
        private readonly IIncreaseCodeService _service;

        public IncreaseCodeController(IIncreaseCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncreaseCode>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncreaseCode>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IncreaseCode increaseCode)
        {
            await _service.AddAsync(increaseCode);
            return CreatedAtAction(nameof(Get), new { id = increaseCode.Id }, increaseCode);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] IncreaseCode increaseCode)
        {
            if (id != increaseCode.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(increaseCode);
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
