using AuthenticationService.DiscoveryClient;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    public class HealthStatusController : ControllerBase
    {

        [HttpGet("/status")]
        public string GetStatus()
        {
            return DiscoveryClientStatus.CurrentStatus;
        }
        [HttpGet("/healthcheck")]
        public string GetHealthCheck()
        {
            return DiscoveryClientHealthCheck.GetHealth();
        }


       
    }
}
