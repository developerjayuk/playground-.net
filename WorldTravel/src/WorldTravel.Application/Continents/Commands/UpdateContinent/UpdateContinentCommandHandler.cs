using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Interface;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Continents.Commands.UpdateContinent;

public class UpdateContinentCommandHandler(ILogger<UpdateContinentCommandHandler> logger, IMapper mapper, IContinentsRepository continentsRepository, IContinentAuthorizationService continentAuthorizationService) 
    : IRequestHandler<UpdateContinentCommand>
{
    public async Task Handle(UpdateContinentCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating continent with Id: {request.Id}");
        var continent = await continentsRepository.GetByIdAsync(request.Id)
        ?? throw new NotFoundException(nameof(Continent), request.Id);

        if (!continentAuthorizationService.Authorize(continent, ResourceOperation.Update))
        {
            logger.LogWarning($"User is not authorized to update continent with Id: {request.Id}");
            throw new ForbidException();
        }

        mapper.Map(request, continent);

        await continentsRepository.SaveChangesAsync();
    }
}

