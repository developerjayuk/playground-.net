namespace WorldTravel.Domain.Entities;

public class Country
{
    // set as ISO Code
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ContinentId { get; set; } = default!;
    public int Population {  get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
    public List<City> Cities { get; set; } = new();

    public User CreatedBy { get; set; } = default!;
    public string CreatedById { get; set; } = default!;

}