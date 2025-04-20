using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Cities.Commands.DeleteCityForCountry;

public class DeleteCityForCountryCommandHandler(ILogger<DeleteCityForCountryCommandHandler> logger, ICountriesRepository countriesRepository, ICitiesRepository citiesRepository) 
    : IRequestHandler<DeleteCityForCountryCommand>
{
    public async Task Handle(DeleteCityForCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting city with Id: {request.CityId} from country with Id: {request.CountryId}");
        var country = await countriesRepository.GetByIdAsync(request.CountryId) 
            ?? throw new NotFoundException(nameof(Country), request.CountryId);

        var city = country.Cities.FirstOrDefault(c => c.Id == request.CityId)
            ?? throw new NotFoundException(nameof(City), request.CityId.ToString());

        await citiesRepository.DeleteAsync(city);
    }
}

