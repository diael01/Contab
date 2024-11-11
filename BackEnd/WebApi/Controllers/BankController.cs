
using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _service;
        public BanksController(IBankService service)
        {
            _service = service;
        }

        // GET: api/Banks [HttpGet]
        public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
        {
            return Ok(await _service.GetBanks());
        }

        // GET: api/Banks/5 [HttpGet("{id}")]
        public async Task<ActionResult<Bank>> GetBank(int id)
        {
            var bank = await _service.GetBank(id);
            if (bank == null)
            {
                return NotFound();
            }
            return Ok(bank);
        }

        // POST: api/Banks [HttpPost]
        public async Task<ActionResult<Bank>> AddBank(Bank bank)
        {
            var newBank = await _service.AddBank(bank);
            return CreatedAtAction(nameof(GetBank), new { id = newBank.Id }, newBank);
        }

        // PUT: api/Banks/5 [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBank(int id, Bank bank)
        {
            if (id != bank.Id)
            {
                return BadRequest();
            }
            await _service.UpdateBank(bank);
            return NoContent();
        }

        // DELETE: api/Banks/5 [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            await _service.DeleteBank(id);
            return NoContent();
        }
    }
}