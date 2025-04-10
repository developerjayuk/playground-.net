using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.WorldTravel.Commands.UpdateCountry;

public class UpdateCountryCommandHandler(ILogger<UpdateCountryCommandHandler> logger, IMapper mapper, ICountriesRepository countriesRepository) 
    : IRequestHandler<UpdateCountryCommand, bool>
{
    public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Updating country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id);

        if (country is null)
        {
            logger.LogError($"Country with Id: {request.Id} not found");
            return false;
        }

        mapper.Map(request, country);

        await countriesRepository.SaveChangesAsync();

        return true;
    }
}

