﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;

namespace WorldTravel.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Assigning userRole: {request.RoleName} for user: {request.UserEmail}");

        var user = await userManager.FindByEmailAsync(request.UserEmail) ?? throw new NotFoundException(nameof(User), request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName) ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.AddToRoleAsync(user, role.Name!);
    }
}

