using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Continents.Commands.CreateContinent;

public class CreateContinentCommandHandler(ILogger<CreateContinentCommandHandler> logger, IMapper mapper,
    IContinentsRepository continentsRepository, IUserContext userContext) 
    : IRequestHandler<CreateContinentCommand, string?>
{
    public async Task<string?> Handle(CreateContinentCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser() ?? throw new InvalidOperationException("User context not available");

        logger.LogInformation("Creating continent: {@continent}", request);
        var continent = mapper.Map<Continent>(request);
        continent.CreatedById = currentUser.Id;

        var id = await continentsRepository.CreateAsync(continent);
        if (id == null)
        {
            logger.LogError("Continent could not be created");
            return id;
        }
        logger.LogInformation("Continent created with id: {Id}", id);
        return id;
    }
}

