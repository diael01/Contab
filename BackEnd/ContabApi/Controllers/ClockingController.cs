
using Contracts.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContabApi.Controllers
{
    [ApiController]
    [Route("api/v1/clock")]
    //[Authorize]
    //[Authorize(Policy = "isAdmin")] //for testing purpose
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ClockingController : ControllerBase
    {
        IClockingService cSvc;

        public ClockingController(IClockingService csvc)
        {
            cSvc = csvc;

        }

        /// <summary>
        /// Calculates the monthly advnce by teh EMployee Id from database
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateClockingOneById")]
        public async Task<IActionResult> UpdateClockingById(string empId)
        {
            //validate
            var avc = await cSvc.UpdateClocking1Async(empId);
            return Ok(avc);
        }

        /// <summary>
        /// Calculates the monthly advance of a specific person BY NAME
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateClockingOneByName")]
        public async Task<IActionResult> UpdateClockingOneByName(string empName)
        {
            //validate
            var avc = await cSvc.UpdateClocking1Async(empName);
            return Ok(avc);
            //return Ok or problem
        }

        /// <summary>
        /// Calculates the monthly advnce by teh EMployee Id from database
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateClockingOneByNode")]
        public async Task<IActionResult> UpdateClockingByNode(string empNode)
        {
            //validate
            var avc = await cSvc.UpdateClocking1Async(empNode);
            return Ok(avc);
        }
    }
}
