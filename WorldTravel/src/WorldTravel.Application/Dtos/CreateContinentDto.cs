namespace WorldTravel.Application.Dtos;

public class CreateContinentDto
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}
