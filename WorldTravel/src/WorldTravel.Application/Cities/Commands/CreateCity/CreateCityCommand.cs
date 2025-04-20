using MediatR;

namespace WorldTravel.Application.Cities.Commands.CreateCity;

public class CreateCityCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? CountryId { get; set; } = default!;
}
