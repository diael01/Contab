using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ContabApi.Controllers
{

    [ApiController]
    [Route("api/v1/param")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ParamController : ControllerBase
    {
        private readonly IParamService _service;

        public ParamController(IParamService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Param>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Param>> Get(short id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Param param)
        {
            await _service.AddAsync(param);
            return CreatedAtAction(nameof(Get), new { id = param.Id }, param);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(short id, [FromBody] Param param)
        {
            if (id != param.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(param);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(short id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }


}
