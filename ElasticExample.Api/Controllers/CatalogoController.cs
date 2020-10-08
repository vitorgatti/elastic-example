using ElasticExample.Domain.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ElasticExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogApplication _catalogApplication;

        public CatalogoController(ICatalogApplication catalogApplication)
        {
            _catalogApplication = catalogApplication;
        }

        [HttpPost]
        public IActionResult PostSampleData()
        {
            _catalogApplication.PostCatalogsSample();

            return Ok(new { Result = "Data successfully registered with Elasticsearch" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _catalogApplication.GetAll();

            return Ok(result);
        }

        [HttpGet("name")]
        public IActionResult GetByName([FromQuery] string sku)
        {
            var result = _catalogApplication.GetBySku(sku);

            return Ok(result);
        }

        [HttpGet("description")]
        public IActionResult GetByDescription([FromQuery] string description)
        {
            var result = _catalogApplication.GetByDescription(description);

            return Ok(result);
        }

    }
}
