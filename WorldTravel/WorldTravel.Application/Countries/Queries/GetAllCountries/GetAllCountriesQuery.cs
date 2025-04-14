using MediatR;
using WorldTravel.Application.Common;
using WorldTravel.Application.Countries.Dtos;
using WorldTravel.Domain.Constants;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQuery : IRequest<PagedResult<CountryDto>>
{
    public string? SearchPhrase { get; set; }
    public int Size { get; set; } = 50;
    public int Page { get; set; } = 1;
    public string? SortBy { get; set; }
    public Sort? Direction { get; set; }
}
