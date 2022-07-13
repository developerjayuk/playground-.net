using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public IConfiguration _config { get; }

        public ConfigurationController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/confguration
        [HttpGet]
        public ActionResult Get()
        {
            var connectionString = _config.GetConnectionString("Default");

            return Ok(connectionString);
        }
    }
}
