using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Interface;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandler(ILogger<UpdateCountryCommandHandler> logger, IMapper mapper, ICountriesRepository countriesRepository, ICountryAuthorizationService countryAuthorizationService) 
    : IRequestHandler<UpdateCountryCommand>
{
    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id)
        ?? throw new NotFoundException(nameof(Country), request.Id);

        if (!countryAuthorizationService.Authorize(country, ResourceOperation.Update))
        {
            logger.LogWarning($"User is not authorized to update country with Id: {request.Id}");
            throw new ForbidException();
        }

        mapper.Map(request, country);

        await countriesRepository.SaveChangesAsync();
    }
}

