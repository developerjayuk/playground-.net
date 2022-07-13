using Microsoft.AspNetCore.Mvc;

namespace BasicApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public IConfiguration _config { get; }

    public UsersController(IConfiguration config)
    {
        _config = config;
    }

    // GET: api/users
    [HttpGet]
    public IEnumerable<string> Get()
    {
        List<string> output = new();
        for (int i = 0; i < Random.Shared.Next(2,10); i++)
        {
            output.Add($"Value #{i+1}");
        }

        return new string[] { "value1", "value2" };
    }

    // GET api/users/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"Value #{id}";
    }

    // POST api/users
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
