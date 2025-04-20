using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandler(ILogger<CreateCountryCommandHandler> logger, IMapper mapper,
    ICountriesRepository countriesRepository, IUserContext userContext) 
    : IRequestHandler<CreateCountryCommand, string?>
{
    public async Task<string?> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser() ?? throw new InvalidOperationException("User context not available");

        logger.LogInformation("Creating country: {@country}", request);
        var country = mapper.Map<Country>(request);
        country.CreatedById = currentUser.Id;

        var id = await countriesRepository.CreateAsync(country);
        if (id == null)
        {
            logger.LogError("Country could not be created");
            return id;
        }
        logger.LogInformation("Country created with id: {Id}", id);
        return id;
    }
}

