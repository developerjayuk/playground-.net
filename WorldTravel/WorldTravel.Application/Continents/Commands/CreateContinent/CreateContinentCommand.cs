using MediatR;

namespace WorldTravel.Application.Continents.Commands.CreateContinent;

public class CreateContinentCommand : IRequest<string?>
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
