using Microsoft.Extensions.Logging;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Interface;

namespace WorldTravel.Infastructure.Authorization.Services;

public class ContinentAuthorizationService(ILogger<ContinentAuthorizationService> logger, IUserContext userContext) : IContinentAuthorizationService
{
    public bool Authorize(Continent continent, ResourceOperation operation)
    {
        var user = userContext.GetCurrentUser() ?? throw new InvalidOperationException("User context not available");

        logger.LogInformation($"Checking authorization for user: {user.Email} on continent: {continent.Name} with operation: {operation}");

        if (operation == ResourceOperation.Read || operation == ResourceOperation.Create)
        {
            logger.LogInformation("Create/Read operation - successful auth");
            return true;
        }

        if (operation == ResourceOperation.Delete && user.IsInRole(UserRoles.Admin))
        {
            logger.LogInformation("Delete operation for admin user - successful auth");
            return true;
        }

        if ((operation == ResourceOperation.Delete || operation == ResourceOperation.Update) && user.Id == continent.CreatedById)
        {
            logger.LogInformation("Delete/Update operation for owner user - successful auth");
            return true;
        }

        return false;
    }
}
