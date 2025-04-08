using Microsoft.Extensions.Logging;
using WorldTravel.Application.WorldTravel.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.WorldTravel;

internal class CountriesService(ICountriesRepository countriesRepository, ILogger<CountriesService> logger) 
    : ICountriesService
{
    public async Task<IEnumerable<CountryDto>> GetAllCountries()
    {
        logger.LogInformation("Getting all countries");
        var countries = await countriesRepository.GetAllAsync();
        var countriesDto = countries.Select(CountryDto.FromEntity);

        return countriesDto!;
    }

    public async Task<CountryDto?> GetCountryById(string id)
    {
        logger.LogInformation("Getting country by id: " + id);
        var country = await countriesRepository.GetByIdAsync(id);
        var countryDto = CountryDto.FromEntity(country);

        return countryDto;
    }
}
