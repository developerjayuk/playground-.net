using MediatR;

namespace WorldTravel.Application.Countries.Commands.UpdateCountry;

public class UpdateCountryCommand() : IRequest
{
    public string Id { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Population { get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
}
