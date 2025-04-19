using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WorldTravel.Application.Users;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = (httpContextAccessor.HttpContext?.User) ?? throw new InvalidOperationException("User context not available");

        if (user.Identity is null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var id = user.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(u => u.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(u => u.Type == ClaimTypes.Role)!.Select(c => c.Value);
        var dateOfBirthString = user.FindFirst(u => u.Type == ClaimTypes.DateOfBirth)?.Value ?? null;
        var dateOfBirth = (DateOnly?)null;

        if (!string.IsNullOrEmpty(dateOfBirthString) && DateOnly.TryParseExact(dateOfBirthString, "yyyy-MM-dd", out var parsedDob))
        {
            dateOfBirth = parsedDob;
        }

        return new CurrentUser(id, email, roles, dateOfBirth);
    }
}

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}
