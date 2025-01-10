
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/clock")]
    public class ClockingController : ControllerBase
    {
        IClockingService cSvc;

        ClockingController(IClockingService csvc)
        {
            cSvc = csvc;

        }

        [HttpPut]
        [Route("UpdateClocking1")]
        public async Task<IActionResult> UpdateClocking1(string empId)
        {
            //validate
            var avc = await cSvc.UpdateClocking1Async(empId);
            return Ok(avc);
            //retunr Ok or problem
        }
    }
}
