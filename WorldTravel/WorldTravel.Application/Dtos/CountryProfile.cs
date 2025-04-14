using AutoMapper;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using WorldTravel.Application.Countries.Commands.UpdateCountry;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Dtos;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CreateCountryCommand, Country>();
        CreateMap<UpdateCountryCommand, Country>();
    }
}
