using MediatR;

namespace WorldTravel.Application.Continents.Commands.UpdateContinent;

public class UpdateContinentCommand() : IRequest
{
    public string Id { get; set; } = default!;
    public string Description { get; set; } = default!;
}
