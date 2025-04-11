using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Cities.Commands.CreateCity;

public class CreateCityCommandHandler(ILogger<CreateCityCommandHandler> logger, IMapper mapper, ICountriesRepository countriesRepository, ICitiesRepository citiesRepository)
    : IRequestHandler<CreateCityCommand, int>
{
    public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating city: {@city}", request);

        var country = await countriesRepository.GetByIdAsync(request.CountryId!) ?? throw new NotFoundException(nameof(Country), request.CountryId!);

        var city = mapper.Map<City>(request);
        var id = await citiesRepository.CreateAsync(city);

        return id;
        // todo add more error handling
    }
}

