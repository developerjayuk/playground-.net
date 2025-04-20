using MediatR;

namespace WorldTravel.Application.Users.Commands.RemoveUserRole;

public class RemoveUserRoleCommand : IRequest
{
    public string RoleName { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
}
