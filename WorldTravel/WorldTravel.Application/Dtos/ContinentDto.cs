namespace WorldTravel.Application.Dtos;

public class ContinentDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<CountryDto> Countries { get; set; } = [];

}