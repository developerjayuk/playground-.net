using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.WorldTravel;

namespace WorldTravel.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ContinentsController(IContinentsService continentsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var continents = await continentsService.GetAllContinents();
        return Ok(continents);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var continent = await continentsService.GetContinentById(id);
        if (continent == null)
        {
            return NotFound();
        }
        return Ok(continent);
    }
}
