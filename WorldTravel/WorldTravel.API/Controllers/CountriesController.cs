using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using WorldTravel.Application.Countries.Commands.DeleteCountry;
using WorldTravel.Application.Countries.Commands.UpdateCountry;
using WorldTravel.Application.Countries.Queries.GetAllCountries;
using WorldTravel.Application.Countries.Queries.GetCountryById;
using WorldTravel.Application.Dtos;

namespace WorldTravel.API.Controllers;


[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CountriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll([FromQuery] GetAllCountriesQuery query)
    {
        var countries = await mediator.Send(query);
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CountryDto?>> GetById([FromRoute] string id)
    {
        var country = await mediator.Send(new GetCountryByIdQuery(id));
        return Ok(country);
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateCountry(CreateCountryCommand command)
    {
        var id = await mediator.Send(command);

        if (id == null)
        {
            return BadRequest("Country could not be created.");
        }
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCountry([FromRoute] string id)
    {
        await mediator.Send(new DeleteCountryCommand(id));
        return NoContent();
    }


    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin, Owner")]
    public async Task<IActionResult> UpdateCountry([FromRoute] string id, UpdateCountryCommand command)
    {
        command.Id = id;

        await mediator.Send(command);
        return NoContent();
    }
}
