using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers.v2;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
[ApiController]
public class ConfigurationController : ControllerBase
{
    public IConfiguration _config { get; }

    public ConfigurationController(IConfiguration config)
    {
        _config = config;
    }

    // GET: api/v2/confguration
    [HttpGet]
    public ActionResult Get()
    {
        var connectionString = _config.GetConnectionString("Default");

        return Ok(connectionString);
    }
}
