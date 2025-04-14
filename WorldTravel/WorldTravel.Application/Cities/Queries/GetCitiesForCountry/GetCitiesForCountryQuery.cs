using MediatR;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Cities.Queries.GetCitiesForCountry;

public class GetCitiesForCountryQuery(string countryId) : IRequest<IEnumerable<CityDto>>
{
    public string CountryId { get;} = countryId;
}
