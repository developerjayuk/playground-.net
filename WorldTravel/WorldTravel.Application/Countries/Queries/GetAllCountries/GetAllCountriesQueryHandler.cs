using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Countries.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQueryHandler(ILogger<GetAllCountriesQueryHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>>
{
    public async Task<IEnumerable<CountryDto>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all countries");
        var countries = await countriesRepository.GetAllAsync();
        var countriesDto = mapper.Map<IEnumerable<CountryDto>>(countries);

        return countriesDto!;
    }
}

