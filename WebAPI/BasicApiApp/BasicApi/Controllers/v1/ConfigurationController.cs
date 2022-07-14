using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers.v1;
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ConfigurationController : ControllerBase
{
    public IConfiguration _config { get; }

    public ConfigurationController(IConfiguration config)
    {
        _config = config;
    }

    // GET: api/v1/confguration
    [HttpGet]
    public ActionResult Get()
    {
        var connectionString = _config.GetConnectionString("Default");

        return Ok(connectionString);
    }
}
