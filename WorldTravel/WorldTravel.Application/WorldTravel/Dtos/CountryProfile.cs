using AutoMapper;
using WorldTravel.Application.WorldTravel.Commands.CreateCountry;
using WorldTravel.Application.WorldTravel.Commands.UpdateCountry;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CreateCountryCommand, Country>();
        CreateMap<UpdateCountryCommand, Country>();
    }
}
