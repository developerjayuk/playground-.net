using MediatR;
using WorldTravel.Application.Countries.Dtos;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDto>>
{
}
