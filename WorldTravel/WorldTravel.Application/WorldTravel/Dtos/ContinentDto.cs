using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class ContinentDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<CountryDto> Countries { get; set; } = new();

    public static ContinentDto FromEntity(Continent continent)
    {
        return new ContinentDto
        {
            Id = continent.Id,
            Name = continent.Name,
            Description = continent.Description,
            //Countries = continent.Countries
            //    .Select(country => CountryDto.FromEntity(country)!)
            //    .ToList() // Explicitly convert to List
        };
    }
}
