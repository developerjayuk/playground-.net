namespace WorldTravel.Application.Dtos;

public class CountryDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ContinentId { get; set; } = default!;
    public int Population { get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
    public List<CityDto> Cities { get; set; } = new();
}
