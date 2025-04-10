using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.WorldTravel.Commands.CreateCountry;
using WorldTravel.Application.WorldTravel.Commands.DeleteCountry;
using WorldTravel.Application.WorldTravel.Commands.UpdateCountry;
using WorldTravel.Application.WorldTravel.Queries.GetAllCountries;
using WorldTravel.Application.WorldTravel.Queries.GetCountryById;

namespace WorldTravel.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countries = await mediator.Send(new GetAllCountriesQuery());
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var country = await mediator.Send(new GetCountryByIdQuery(id));
        if (country == null)
        {
            return NotFound();
        }
        return Ok(country);
    }

    [HttpPost]
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
    public async Task<IActionResult> DeleteCountry([FromRoute] string id)
    {
        var isDeleted = await mediator.Send(new DeleteCountryCommand(id));
        if (isDeleted)
        {
            return NoContent();
        }
        return NotFound();
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCountry([FromRoute] string id, UpdateCountryCommand command)
    {
        command.Id = id;

        var isUpdated = await mediator.Send(new UpdateCountryCommand());
        if (isUpdated)
        {
            return NoContent();
        }
        return NotFound();
    }
}
