using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.Continents.Commands.CreateContinent;
using WorldTravel.Application.Continents.Commands.DeleteContinent;
using WorldTravel.Application.Continents.Commands.UpdateContinent;
using WorldTravel.Application.Continents.Queries.GetAllContinents;
using WorldTravel.Application.Continents.Queries.GetContinentById;
using WorldTravel.Application.Dtos;

namespace WorldTravel.API.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]

public class ContinentsController(IMediator mediator) : ControllerBase
{
 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContinentDto>>> GetAll([FromQuery] GetAllContinentsQuery query)
    {
        var countries = await mediator.Send(query);
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContinentDto?>> GetById([FromRoute] string id)
    {
        var country = await mediator.Send(new GetContinentByIdQuery(id));
        return Ok(country);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateContinent(CreateContinentCommand command)
    {
        var id = await mediator.Send(command);

        if (id == null)
        {
            return BadRequest("Continent could not be created.");
        }
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteContinent([FromRoute] string id)
    {
        await mediator.Send(new DeleteContinentCommand(id));
        return NoContent();
    }


    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin, Owner")]
    public async Task<IActionResult> UpdateContinent([FromRoute] string id, UpdateContinentCommand command)
    {
        command.Id = id;

        await mediator.Send(command);
        return NoContent();
    }
}
