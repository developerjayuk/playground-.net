using MediatR;

namespace WorldTravel.Application.Cities.Commands.DeleteCityForCountry;

public class DeleteCityForCountryCommand(string countryId, int cityId) : IRequest
{
    public string CountryId { get; } = countryId;
    public int CityId { get; } = cityId;
}
