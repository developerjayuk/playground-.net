using AutoMapper;
using WorldTravel.Application.Cities.Commands.CreateCity;
using WorldTravel.Application.Cities.Dtos;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Countries.Dtos;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CreateCityCommand, City>();
        CreateMap<City, CityDto>();
    }
}
