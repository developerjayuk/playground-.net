using MediatR;
using WorldTravel.Application.Common;
using WorldTravel.Application.Countries.Dtos;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<PagedResult<CountryDto>>
{
    public string? SearchPhrase { get; set; }
    public int Size { get; set; }
    public int Page { get; set; }
}
