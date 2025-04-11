using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandler(ILogger<UpdateCountryCommandHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) 
    : IRequestHandler<UpdateCountryCommand>
{
    public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException(nameof(Country), request.Id);
        mapper.Map(request, country);

        await countriesRepository.SaveChangesAsync();
    }
}

