using MediatR;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.WorldTravel.Commands.UpdateCountry;

public class UpdateCountryCommand() : IRequest<bool>
{
    public string Id { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Population { get; set; } = default!;
    public int NumberOfTourists { get; set; } = default!;
}
