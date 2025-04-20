using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Common;
using WorldTravel.Application.Dtos;
using WorldTravel.Domain.Repositories;

namespace WorldTravel.Application.Continents.Queries.GetAllContinents;

public class GetAllContinentsQueryHandler(ILogger<GetAllContinentsQueryHandler> logger, IMapper mapper, IContinentsRepository continentsRepository) : IRequestHandler<GetAllContinentsQuery, PagedResult<ContinentDto>>
{
    public async Task<PagedResult<ContinentDto>> Handle(GetAllContinentsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all continents");

        var (continents, totalCount) = await continentsRepository.GetAllAsync();
        var continentsDto = mapper.Map<IEnumerable<ContinentDto>>(continents);

        var result = new PagedResult<ContinentDto>(continentsDto, totalCount, request.Size, request.Page);
        return result;
    }
}

