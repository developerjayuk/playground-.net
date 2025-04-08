using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class ContinentDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class ContinentFullDto : ContinentDto
{
    public List<CountryDto> Countries { get; set; } = [];
}
