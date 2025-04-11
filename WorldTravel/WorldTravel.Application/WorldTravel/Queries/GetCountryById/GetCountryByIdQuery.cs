using MediatR;
using WorldTravel.Application.WorldTravel.Dtos;

namespace WorldTravel.Application.WorldTravel.Queries.GetCountryById;

public class GetCountryByIdQuery(string id) : IRequest<CountryDto>
{
    public string Id { get; } = id;
}
