
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/clock")]
    public class ClockingController : ControllerBase
    {

        //[HttpPut]
        //[Route("UpdateClocking1")]
        //public async Task<IActionResult> UpdateClocking1()
        //{
        //    //calculare MoneyAdvance = AVC pt toti angajatii

        //    //validate
        //    //tre sa iau zire, CAV sau RN8,ZAP8 din Params si il folosesc la algoritmul pt calculare AVG-ului
        //    //AdvancePercentate=CAV
        //    //NormatedRegime = RN8
        //    //NoOfDaysForWhichAdvanceisPaid = ZAP8
        //    //pt constructii unu dna cociorva a decis asta
        //    //var avc = int(int(retrib / rn8 * zap8) / 10) * 10; //avans pt oamenii normali dar sunt si exceptiii
        //    //----------------------------------------
        //    //if (zire == 0)
        //    //    var avc = (retrib * 0.5 * CAV) / 100;
        //    //else
        //    //{
        //    //    //var avc = int(int(retrib / rn8 * zire) / 10) * 10;
        //    //    var avc = retrib * 0.5 * zire*cav/(100*8);//nu tre sa fie 8 , tre sa fie 
        //    //                                            //cate ore pe zi munceste omul , de exemplu
        //    //                                            //poa sa fie 4
        //    //}
        //    //--------------------------------------------
        //}
    }
}
