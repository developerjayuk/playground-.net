using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.WorldTravel.Commands.DeleteCountry;

public class DeleteCountryCommandHandler(ILogger<DeleteCountryCommandHandler> logger, ICountriesRepository countriesRepository) 
    : IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Country), request.Id);
        await countriesRepository.DeleteAsync(country);
    }
}

