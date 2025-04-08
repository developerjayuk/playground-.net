using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class CountryDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ContinentDto Continent { get; set; } = default!;
    public string ContinentId { get; set; } = default!;
    public int Population { get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;

    public static CountryDto? FromEntity(Country? country)
    {
        if (country == null) 
        {
            return null;
        }

        return new CountryDto
        {
            Id = country.Id,
            Name = country.Name,
            Description = country.Description,
            Population = country.Population,
            NumberOfTourists = country.NumberOfTourists,
            Continent = ContinentDto.FromEntity(country.Continent)
        };
    }
}
