using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Dtos;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Continents.Queries.GetContinentById;

public class GetContinentByIdQueryHandler(ILogger<GetContinentByIdQueryHandler> logger, IMapper mapper, IContinentsRepository continentsRepository) 
    : IRequestHandler<GetContinentByIdQuery, ContinentDto>
{
    public async Task<ContinentDto> Handle(GetContinentByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting continent by id: {request.Id}");
        var continent = await continentsRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(Continent), request.Id);
        var continentDto = mapper.Map<ContinentDto>(continent);

        return continentDto;
    }
}

