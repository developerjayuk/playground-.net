using MediatR;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Countries.Queries.GetCountryById;

public class GetCountryByIdQuery(string id) : IRequest<CountryDto>
{
    public string Id { get; } = id;
}
