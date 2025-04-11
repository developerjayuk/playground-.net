using MediatR;
using WorldTravel.Application.Countries.Dtos;

namespace WorldTravel.Application.Countries.Queries.GetCountryById;

public class GetCountryByIdQuery(string id) : IRequest<CountryDto>
{
    public string Id { get; } = id;
}
