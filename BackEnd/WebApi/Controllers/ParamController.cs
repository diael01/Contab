using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/v1/param")]
    public class ParamsController : ControllerBase
    {
        private readonly IParamService _service;
        public ParamsController(IParamService service)
        {
            _service = service;
        }
        // GET: api/Params
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Param>>> GetParams()
        {
            return Ok(await _service.GetParams());
        }
        // GET: api/Params/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Param>> GetParam(short id)
        {
            var param = await _service.GetParam(id);
            if (param == null)
            {
                return NotFound();
            }
            return Ok(param);
        }
        // POST: api/Params
        [HttpPost]
        public async Task<ActionResult<Param>> AddParam(Param param)
        {
            var newParam = await _service.AddParam(param);
            return CreatedAtAction(nameof(GetParam), new { id = newParam.Id }, newParam);
        }
        // PUT: api/Params/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParam(short id, Param param)
        {
            // 11 / 14 / 24, 6:24 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/2
            if (id != param.Id)
            {
                return BadRequest();
            }
            await _service.UpdateParam(param);
            return NoContent();
        }
        // DELETE: api/Params/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParam(short id)
        {
            await _service.DeleteParam(id);
            return NoContent();
        }
    }

}
