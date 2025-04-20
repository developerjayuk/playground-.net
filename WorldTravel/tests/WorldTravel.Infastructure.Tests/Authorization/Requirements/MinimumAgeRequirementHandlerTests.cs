using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Moq;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using WorldTravel.Infastructure.Authorization.Requirements;
using Xunit;

namespace WorldTravel.Infastructure.Tests.Authorization.Requirements;

public class MinimumAgeRequirementHandlerTests
{
    // todo - fix the test
    [Fact(Skip = "Skipping this test temporarily.")]
    public async Task HandleRequirementAsync_UserMeetsMinimumAgeRequirement_ShouldSucceed()
    {
        // Arrange
        var dob = new DateOnly(1970, 1, 1);

        var currentUser = new CurrentUser("123", "test@email.com", [], dob);
        var loggerMock = new Mock<ILogger<MinimumAgeRequirementHandler>>(); 
        var userContextMock = new Mock<IUserContext>();
        userContextMock.Setup(u => u.GetCurrentUser()).Returns(currentUser);

        var country = new Country
        {
            Id = "IT",
            Description = "Beautiful country in Europe",
            Population = 60000000,
            NumberOfTourists = 100000000
        };

        var countriesRepositoryMock = new Mock<ICountriesRepository>();
        countriesRepositoryMock
            .Setup(r => r.GetByIdAsync("IT"))
            .ReturnsAsync(country!);

        var requirement = new MinimumAgeRequirement(18);
        var authorizationHandler = new MinimumAgeRequirementHandler(loggerMock.Object, userContextMock.Object);
        var context = new AuthorizationHandlerContext([requirement], null, null);

        // Act
        await authorizationHandler.HandleAsync(context);

        // Assert
        context.HasSucceeded.Should().BeTrue();
    }
}
