
using Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Contracts.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/clock")]
    public class ClockingController : ControllerBase
    {
        IParamService paramSvc;
        IEmpService empSvc;
        ClockingController(IParamService psvc, IEmpService esvc)
        {
            paramSvc = psvc;
            empSvc = esvc;
        }

        [HttpPut]
        [Route("UpdateClocking1")]
        public async Task<IActionResult> UpdateClocking1(string empId)
        {
            var param = await paramSvc.GetByIdAsync(1);//the one and only updated record in this table
            var emp = await empSvc.GetEmployeeById(empId);

            //calculare MoneyAdvance = AVC pt toti angajatii

            //validate
            //tre sa iau zire, CAV sau RN8,ZAP8 din Params si il folosesc la algoritmul pt calculare AVG-ului
            //AdvancePercentate=CAV
            //NormatedRegime = RN8
            //NoOfDaysForWhichAdvanceisPaid = ZAP8
            //pt constructii unu dna cociorva a decis asta
            //var avc = int(int(retrib / rn8 * zap8) / 10) * 10; //avans pt oamenii normali dar sunt si exceptiii



            //----------------------------------------
            //if (zire == 0)
            //    var avc = (retrib * 0.5 * CAV) / 100;
            //else
            //{
            //    //var avc = int(int(retrib / rn8 * zire) / 10) * 10;
            //    var avc = retrib * 0.5 * zire*cav/(100*8);//nu tre sa fie 8 , tre sa fie 
            //                                            //cate ore pe zi munceste omul , de exemplu
            //                                            //poa sa fie 4
            //}
            //--------------------------------------------
            if (emp.ExceptedRetributionDays == 0)
            {
                var avc = emp.MainSalary * (decimal)0.5 * param.AdvancePercentRate;
            } 
            else
            {
                var avc = emp.MainSalary * (decimal)0.5 * emp.ExceptedRetributionDays * param.AdvancePercentRate / (100 * 8);
                //nu tre sa fie 8 , tre sa fie //cate ore pe zi munceste omul , de exemplu poa sa fie 4
            }
            //unde updatez? si returnez avc sau to employyeul?
            return null;
           


        }
    }
}
