﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.Cities.Commands.CreateCity;
using WorldTravel.Application.Cities.Commands.DeleteCityForCountry;
using WorldTravel.Application.Cities.Queries.GetCitiesForCountry;
using WorldTravel.Application.Cities.Queries.GetCityById;
using WorldTravel.Application.Countries.Commands.UpdateCountry;
using WorldTravel.Application.Dtos;

namespace WorldTravel.API.Controllers;


[ApiController]
//[Authorize]
[Route("api/countries/{countryId}/[controller]")]
public class CitiesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CityDto>>> GetAllForCountry([FromRoute] string id)
    {
        var cities = await mediator.Send(new GetCitiesForCountryQuery(id));
        return Ok(cities);
    }

    [HttpGet("{cityId}")]
    public async Task<ActionResult<CityDto?>> GetCityById([FromRoute] string countryId, [FromRoute] int cityId)
    {
        var city = await mediator.Send(new GetCityByIdQuery(countryId, cityId));
        return Ok(city);
    }

    [HttpDelete("{cityId}")]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCityForCountry([FromRoute] string countryId, [FromRoute] int cityId)
    {
        await mediator.Send(new DeleteCityForCountryCommand(countryId, cityId));
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateCity([FromRoute] string countryId, CreateCityCommand command)
    {
        command.CountryId = countryId;
        var cityId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetCityById), new { countryId, cityId });
    }


    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin, Owner")]
    public async Task<IActionResult> UpdateCountry([FromRoute] string id, UpdateCountryCommand command)
    {
        command.Id = id;

        await mediator.Send(new UpdateCountryCommand());
        return NoContent();
    }
}
