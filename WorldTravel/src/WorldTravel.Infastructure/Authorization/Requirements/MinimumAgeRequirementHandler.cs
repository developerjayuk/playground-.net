using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WorldTravel.Application.Users;

namespace WorldTravel.Infastructure.Authorization.Requirements;

public class MinimumAgeRequirementHandler(ILogger<MinimumAgeRequirementHandler> logger, IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        var currentUser = userContext.GetCurrentUser() ?? throw new InvalidOperationException("User context not available");

        logger.LogInformation($"Checking minimum age requirement for user: {currentUser.Email} with date of birth: {currentUser.DateOfBirth}");

        if (currentUser.DateOfBirth is null)
        {
            logger.LogWarning($"User {currentUser.Email} does not have a date of birth set.");
            context.Fail();
            return Task.CompletedTask;
        }

        if (currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.UtcNow))
        {
            logger.LogInformation($"User {currentUser.Email} meets the minimum age requirement of {requirement.MinimumAge} years.");
            context.Succeed(requirement);
        }
        else
        {
            logger.LogWarning($"User {currentUser.Email} does not meet the minimum age requirement of {requirement.MinimumAge} years.");
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
