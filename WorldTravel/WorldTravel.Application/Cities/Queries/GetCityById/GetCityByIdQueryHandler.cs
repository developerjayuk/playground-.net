using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Dtos;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Cities.Queries.GetCityById;

public class GetCityByIdQueryHandler(ILogger<GetCityByIdQueryHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) 
    : IRequestHandler<GetCityByIdQuery, CityDto>
{
    public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Gettings city with id: {request.CityId} from country with id: {request.CountryId} ");
        var country = await countriesRepository.GetByIdAsync(request.CountryId) ?? throw new NotFoundException(nameof(Country), request.CountryId);
        
        var city = country.Cities.FirstOrDefault(c => c.Id == request.CityId) ?? throw new NotFoundException(nameof(City), request.CityId.ToString());
        var cityDto = mapper.Map<CityDto>(city);

        return cityDto;
    }
}

