using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldTravel.Application.Users.Commands.AssignUserRole;
using WorldTravel.Application.Users.Commands.RemoveUserRole;
using WorldTravel.Application.Users.Commands.UpdateUserDetails;
using WorldTravel.Domain.Constants;

namespace WorldTravel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> RemoveUserRole(RemoveUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}
