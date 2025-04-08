using AutoMapper;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class ContinentProfile : Profile
{
    public ContinentProfile()
    {
        CreateMap<Continent, ContinentDto>();
    }
}
