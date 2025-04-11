using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Countries.Dtos;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Queries.GetCountryById;

public class GetCountryByIdQueryHandler(ILogger<GetCountryByIdQueryHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) 
    : IRequestHandler<GetCountryByIdQuery, CountryDto>
{
    public async Task<CountryDto> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting country by id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Country), request.Id);
        var countryDto = mapper.Map<CountryDto>(country);

        return countryDto;
    }
}

