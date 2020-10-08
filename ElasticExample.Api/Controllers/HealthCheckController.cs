using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElasticExample.Api.Controllers
{
    [Route("/")]
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return Ok(string.Format("Elastic Example API v.{0}", fvi.FileVersion));
        }
    }
}
