using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.WorldTravel.Commands.DeleteCountry;

public class DeleteCountryCommandHandler(ILogger<DeleteCountryCommandHandler> logger, ICountriesRepository countriesRepository) 
    : IRequestHandler<DeleteCountryCommand, bool>
{
    public async Task<bool> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting country with Id: {request.Id}");
        var country = await countriesRepository.GetByIdAsync(request.Id);

        if (country is null)
        {
            logger.LogError($"Country with Id: {request.Id} not found");
            return false;
        }

        await countriesRepository.DeleteAsync(country);
        return true;
    }
}

