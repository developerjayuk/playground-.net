using Microsoft.AspNetCore.Authorization;

namespace WorldTravel.Infastructure.Authorization.Requirements;

public class MinimumAgeRequirement(int minAge) : IAuthorizationRequirement
{
    public int MinimumAge { get; } = minAge;
}
