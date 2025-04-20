using MediatR;
using WorldTravel.Application.Common;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Continents.Queries.GetAllContinents;

public class GetAllContinentsQuery : IRequest<PagedResult<ContinentDto>>
{
    public int Size { get; set; } = 50;
    public int Page { get; set; } = 1;
}
