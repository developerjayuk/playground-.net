using MediatR;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Continents.Queries.GetContinentById;

public class GetContinentByIdQuery(string id) : IRequest<ContinentDto>
{
    public string Id { get; } = id;
}
