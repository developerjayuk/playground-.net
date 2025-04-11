using AutoMapper;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Countries.Dtos;

public class ContinentProfile : Profile
{
    public ContinentProfile()
    {
        CreateMap<Continent, ContinentDto>();
    }
}
