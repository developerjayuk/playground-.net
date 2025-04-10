using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.WorldTravel;
using WorldTravel.Application.WorldTravel.Dtos;

namespace WorldTravel.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountriesService countriesService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countries = await countriesService.GetAllCountries();
        return Ok(countries);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        var country = await countriesService.GetCountryById(id);
        if (country == null)
        {
            return NotFound();
        }
        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDto createCountry)
    {
        var id = await countriesService.CreateCountry(createCountry);

        if (id == null)
        {
            return BadRequest("Country could not be created.");
        }
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
