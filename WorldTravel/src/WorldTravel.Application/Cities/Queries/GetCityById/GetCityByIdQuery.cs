using MediatR;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Cities.Queries.GetCityById;

public class GetCityByIdQuery(string id, int cityId) : IRequest<CityDto>
{
    public string CountryId { get; } = id;
    public int CityId { get; } = cityId;

}
