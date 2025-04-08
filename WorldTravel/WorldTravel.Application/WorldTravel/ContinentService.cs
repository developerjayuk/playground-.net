using Microsoft.Extensions.Logging;
using WorldTravel.Application.WorldTravel.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.WorldTravel;

internal class ContinentsService(IContinentsRepository continentsRepository, ILogger<ContinentsService> logger)
    : IContinentsService
{
    public async Task<IEnumerable<ContinentDto>> GetAllContinents()
    {
        logger.LogInformation("Getting all continents");
        var continents = await continentsRepository.GetAllAsync();
        var continentsDto = continents.Select(ContinentDto.FromEntity);

        return continentsDto!;
    }

    public async Task<ContinentDto?> GetContinentById(string id)
    {
        logger.LogInformation("Getting country by id: " + id);
        var continent = await continentsRepository.GetByIdAsync(id);

        if (continent == null)
        {
            logger.LogWarning("Continent with id: {Id} not found", id);
            return null;
        }

        var continentDto = ContinentDto.FromEntity(continent);

        return continentDto;
    }
}
