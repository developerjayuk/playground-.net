using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.WorldTravel;
using WorldTravel.Application.WorldTravel.Dtos;

namespace WorldTravel.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ContinentsController(IContinentsService continentsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContinentDto>>> GetAll()
    {
        var continents = await continentsService.GetAllContinents();
        return Ok(continents);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContinentDto?>> GetById([FromRoute] string id)
    {
        var continent = await continentsService.GetContinentById(id);
        if (continent == null)
        {
            return NotFound();
        }
        return Ok(continent);
    }
}
