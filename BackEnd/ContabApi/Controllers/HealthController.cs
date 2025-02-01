using Contracts.Exceptions;
using Contracts.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ContabApi.Controllers
{
    [ApiController]
    [Route("/api/health")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class HealthController : ControllerBase
    {
        IServiceProvider Service { get; set; }
        public HealthController(IServiceProvider svc)
        {
            Service = svc;
        }

        [HttpGet]
        [Route("GetHealth")]
        public string? GetHealth()
        {
            var settings = Service.GetService<AppSettings>();
            var ret = (settings != null) ? string.Format(Constants.Health, settings!.ApplicationName, settings!.Version) : null;
            return ret;
        }

        [HttpGet]
        [Route("GetHealthThrowException")]
        public string? GetHealthThrowException()
        {
            throw new ContabApiException(Constants.TestException);
        }
    }
}
