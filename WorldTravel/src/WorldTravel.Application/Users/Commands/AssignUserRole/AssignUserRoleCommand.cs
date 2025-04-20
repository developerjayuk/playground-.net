using MediatR;

namespace WorldTravel.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string RoleName { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
}
