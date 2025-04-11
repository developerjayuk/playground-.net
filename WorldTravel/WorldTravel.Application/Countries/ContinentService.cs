using AutoMapper;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Countries.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries;

internal class ContinentsService(IContinentsRepository continentsRepository, ILogger<ContinentsService> logger, IMapper mapper)
    : IContinentsService
{
    public async Task<IEnumerable<ContinentDto>> GetAllContinents()
    {
        logger.LogInformation("Getting all continents");
        var continents = await continentsRepository.GetAllAsync();
        var continentsDto = mapper.Map<IEnumerable<ContinentDto>>(continents);

        return continentsDto!;
    }

    public async Task<ContinentDto?> GetContinentById(string id)
    {
        logger.LogInformation("Getting country by Id: {Id}", id);
        var continent = await continentsRepository.GetByIdAsync(id);

        if (continent == null)
        {
            logger.LogWarning("Continent with Id: {Id} not found", id);
            return null;
        }

        var continentDto = mapper.Map<ContinentDto>(continent);

        return continentDto;
    }
}
