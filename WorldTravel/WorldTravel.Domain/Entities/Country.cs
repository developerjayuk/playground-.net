namespace WorldTravel.Domain.Entities;

public class Country
{
    // set as ISO Code
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Continent Continent { get; set; } = default!;
    public string ContinentId { get; set; } = default!;
    public int Population {  get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
}