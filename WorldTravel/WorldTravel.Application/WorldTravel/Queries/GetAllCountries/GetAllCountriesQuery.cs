using MediatR;
using WorldTravel.Application.WorldTravel.Dtos;

namespace WorldTravel.Application.WorldTravel.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
{
}
