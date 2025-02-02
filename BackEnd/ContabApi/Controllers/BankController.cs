
using Contracts.Interfaces;
using Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContabApi.Controllers
{
    [ApiController]
    [Route("api/v1/bank")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class BankController : ControllerBase
    {
        private readonly IBankService _service;

        public BankController(IBankService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Bank bank)
        {
            await _service.AddAsync(bank);
            return CreatedAtAction(nameof(Get), new { id = bank.Id }, bank);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(bank);
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