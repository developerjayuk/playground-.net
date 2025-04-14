using AutoMapper;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Dtos;

public class ContinentProfile : Profile
{
    public ContinentProfile()
    {
        CreateMap<Continent, ContinentDto>();
    }
}
