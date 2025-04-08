using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.WorldTravel;

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
}
