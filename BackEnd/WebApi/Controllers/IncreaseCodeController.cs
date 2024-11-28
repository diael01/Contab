using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services;

namespace WebApi.Controllers
{
    [Route("/api/v1/incode")]
    [ApiController]
    public class IncreaseCodeController : ControllerBase
    {
        private readonly IncreaseCodeService _service; public IncreaseCodeController(IncreaseCodeService service) { _service = service; }
        [HttpGet] public async Task<ActionResult<IEnumerable<IncreaseCode>>> GetAll() { var increaseCodes = await _service.GetAll(); return Ok(increaseCodes); }
        [HttpGet("{id}")] public async Task<ActionResult<IncreaseCode>> GetById(int id) { var increaseCode = await _service.GetById(id); if (increaseCode == null) { return NotFound(); } return Ok(increaseCode); }
        [HttpPost] public async Task<ActionResult<IncreaseCode>> Create([FromBody] IncreaseCode increaseCode) { var createdIncreaseCode = await _service.Create(increaseCode); return CreatedAtAction(nameof(GetById), new { id = createdIncreaseCode.Id }, createdIncreaseCode); }
        [HttpPut("{id}")] public async Task<IActionResult> Update(int id, [FromBody] IncreaseCode increaseCode) { if (id != increaseCode.Id) { return BadRequest(); } await _service.Update(increaseCode); return NoContent(); }
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { await _service.Delete(id); return NoContent(); }
    }
}
