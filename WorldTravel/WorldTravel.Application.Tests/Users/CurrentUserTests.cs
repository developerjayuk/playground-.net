using FluentAssertions;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using Xunit;

namespace WorldTravel.Application.Tests.Users;

public class CurrentUserTests
{
    // naming convention for test methods:  
    // [MethodName_Scenario_ExpectedResult]  
    [Fact()]
    public void IsInRole_WithMatchingRole_ShouldReturnTrue()
    {
        // Arrange  
        var currentUser = new CurrentUser("1", "test@test.com", [ UserRoles.User, UserRoles.Admin ], null);

        // Act  
        var result = currentUser.IsInRole(UserRoles.Admin);

        // Assert  
        result.Should().BeTrue();
    }

    [Fact()]
    public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        // Arrange  
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.User, UserRoles.Admin], null);

        // Act  
        var result = currentUser.IsInRole(UserRoles.Owner);

        // Assert  
        result.Should().BeFalse();
    }
}
