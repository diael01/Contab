using Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HolidaysController : ControllerBase
    {
        private readonly IHolidayService _service;
        public HolidaysController(IHolidayService service)
        {
            _service = service;
        }

        // GET: api/Holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetHolidays()
        {
            return Ok(await _service.GetHolidays());
        }

        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holiday>> GetHoliday(int id)
        {
            var holiday = await _service.GetHoliday(id);
            if (holiday == null)
            {
                return NotFound();
            }
            return Ok(holiday);
        }

        // POST: api/Holidays
        [HttpPost]
        public async Task<ActionResult<Holiday>> AddHoliday(Holiday holiday)
        {
            var newHoliday = await _service.AddHoliday(holiday);
            return CreatedAtAction(nameof(GetHoliday), new { id = newHoliday.Id }, newHoliday);
        }

        // PUT: api/Holidays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHoliday(int id, Holiday holiday)
        {
            //11 / 13 / 24, 12:38 PM Microsoft Copilot: Your AI companion
            //https://copilot.microsoft.com/chats/ttjMFevbDYitD9vWxbr4J 1/2
            if (id != holiday.Id)
            {
                return BadRequest();
            }
            await _service.UpdateHoliday(holiday);
            return NoContent();
        }

        // DELETE: api/Holidays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(int id)
        {
            await _service.DeleteHoliday(id);
            return NoContent();
        }
    }
}

