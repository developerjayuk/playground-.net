using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Cities.Dtos;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Cities.Queries.GetCitiesForCountry;

public class GetCitiesForCountryQueryHandler(ILogger<GetCitiesForCountryQueryHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) : IRequestHandler<GetCitiesForCountryQuery, IEnumerable<CityDto>>
{
    public async Task<IEnumerable<CityDto>> Handle(GetCitiesForCountryQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting all cities for Country with Id: {request.CountryId}");

        var country = await countriesRepository.GetByIdAsync(request.CountryId) ?? throw new NotFoundException(nameof(Country), request.CountryId);
        var citiesDto = mapper.Map<IEnumerable<CityDto>>(country.Cities);

        return citiesDto;
    }
}

