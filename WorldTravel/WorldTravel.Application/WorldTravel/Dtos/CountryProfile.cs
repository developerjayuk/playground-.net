using AutoMapper;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<CountryCreateDto, Country>();
        //.ForMember(dest => dest.Continent, opt => opt.Ignore())
        //.ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Country, CountryDto>();
            }
}
