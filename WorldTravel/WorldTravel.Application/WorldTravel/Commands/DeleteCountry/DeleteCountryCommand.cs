using MediatR;

namespace WorldTravel.Application.WorldTravel.Commands.DeleteCountry;

public class DeleteCountryCommand(string id) : IRequest<bool>
{
    public string Id { get; } = id;
}
