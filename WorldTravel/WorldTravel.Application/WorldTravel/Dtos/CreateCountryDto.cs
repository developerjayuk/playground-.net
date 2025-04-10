using System.ComponentModel.DataAnnotations;

namespace WorldTravel.Application.WorldTravel.Dtos;

public class CreateCountryDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ContinentId { get; set; } = default!;
    public int Population { get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
}
