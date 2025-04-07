using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContabApi.Controllers
{
    [ApiController]
    [Route("api/v1/report")]
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ReportController : ControllerBase
    {

        //[HttpGet]
        //[Route("GetReportOfAdvancePaymentAfterClocking1")] //20  pagini
        //public async Task<IActionResult> GetReportOfAdvancePaymentAfterClocking1()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

        //[HttpGet]
        //[Route("GetTotalAdvanceCentralizeWorkersAfterClocking1")] //2 pagini
        //public async Task<IActionResult> GetTotalAdvanceCentralizerWorkersAfterClocking1()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

        //[HttpGet]
        //[Route("GetTotalAdvanceCentralizerOfficeWorkerAfterClocking1")]
        //public async Task<IActionResult> GetTotalAdvanceCentralizerOfficeWorkerAfterClocking1()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

        //[HttpGet]
        //[Route("GetWorkerPaymentPerBank")]
        //public async Task<IActionResult> GetWorkerPaymentPerBank(string BankCode)
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

        //[HttpGet]
        //[Route("GetWorkerPaymentNoCard")]
        //public async Task<IActionResult> GetWorkerPaymentNoCard()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}


        //[HttpGet]
        //[Route("GetCSVListsForBanks")]
        //public async Task<IActionResult> GetCSVListsForBanks()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

        //[HttpGet]
        //[Route("GetExcelListsForBanks")]
        //public async Task<IActionResult> GetExcelListsforBanks()
        //{
        //    //var emps = await EmployeeService.GetEmployeesByLevel(level);
        //    //return Ok(emps);
        //    //inex
        //}

    }
}
