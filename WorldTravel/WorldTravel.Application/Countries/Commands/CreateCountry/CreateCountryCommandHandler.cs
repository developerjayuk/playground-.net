﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandler(ILogger<CreateCountryCommandHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) 
    : IRequestHandler<CreateCountryCommand, string?>
{
    public async Task<string?> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating country: {@country}", request);
        var country = mapper.Map<Country>(request);
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

