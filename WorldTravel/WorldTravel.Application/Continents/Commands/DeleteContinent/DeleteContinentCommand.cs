using MediatR;

namespace WorldTravel.Application.Continents.Commands.DeleteContinent;

public class DeleteContinentCommand(string id) : IRequest
{
    public string Id { get; } = id;
}
