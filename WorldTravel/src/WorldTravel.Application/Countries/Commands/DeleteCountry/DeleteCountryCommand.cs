using MediatR;

namespace WorldTravel.Application.Countries.Commands.DeleteCountry;

public class DeleteCountryCommand(string id) : IRequest
{
    public string Id { get; } = id;
}
