using AutoMapper;
using WorldTravel.Application.Cities.Commands.CreateCity;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Dtos;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CreateCityCommand, City>();
        CreateMap<City, CityDto>();
    }
}
