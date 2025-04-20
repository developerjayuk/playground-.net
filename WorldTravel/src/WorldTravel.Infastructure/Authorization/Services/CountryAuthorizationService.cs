using Microsoft.Extensions.Logging;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Interface;

namespace WorldTravel.Infastructure.Authorization.Services;

public class CountryAuthorizationService(ILogger<CountryAuthorizationService> logger, IUserContext userContext) : ICountryAuthorizationService
{
    public bool Authorize(Country country, ResourceOperation operation)
    {
        var user = userContext.GetCurrentUser() ?? throw new InvalidOperationException("User context not available");

        logger.LogInformation($"Checking authorization for user: {user.Email} on country: {country.Name} with operation: {operation}");

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

        if ((operation == ResourceOperation.Delete || operation == ResourceOperation.Update) && user.Id == country.CreatedById)
        {
            logger.LogInformation("Delete/Update operation for owner user - successful auth");
            return true;
        }

        return false;
    }
}
