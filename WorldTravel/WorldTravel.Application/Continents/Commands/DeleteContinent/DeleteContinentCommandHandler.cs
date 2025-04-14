using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Interface;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Continents.Commands.DeleteContinent;

public class DeleteContinentCommandHandler(ILogger<DeleteContinentCommandHandler> logger, IContinentsRepository continentsRepository, IContinentAuthorizationService continentAuthorizationService) 
    : IRequestHandler<DeleteContinentCommand>
{
    public async Task Handle(DeleteContinentCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting country with Id: {request.Id}");
        var continent = await continentsRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Continent), request.Id);

        if (!continentAuthorizationService.Authorize(continent, ResourceOperation.Delete))
        {
            logger.LogWarning($"User is not authorized to delete continent with Id: {request.Id}");
            throw new ForbidException();
        }

        await continentsRepository.DeleteAsync(continent);
    }
}

