using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Interface;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Commands.DeleteCountry;

public class DeleteCountryCommandHandler(ILogger<DeleteCountryCommandHandler> logger, ICountriesRepository countriesRepository, ICountryAuthorizationService countryAuthorizationService) 
    : IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Country), request.Id);

        if (!countryAuthorizationService.Authorize(country, ResourceOperation.Delete))
        {
            logger.LogWarning($"User is not authorized to delete country with Id: {request.Id}");
            throw new ForbidException();
        }

        await countriesRepository.DeleteAsync(country);
    }
}

