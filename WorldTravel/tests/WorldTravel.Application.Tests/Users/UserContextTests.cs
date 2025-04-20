using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using Xunit;

namespace WorldTravel.Application.Tests.Users;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        // Arrange  
        var dob = new DateOnly(1990, 10, 15);

        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        List<Claim> claims =
        [
            new (ClaimTypes.NameIdentifier, "99"),
            new (ClaimTypes.Email, "test@email.com"),
            new (ClaimTypes.Role, UserRoles.Admin),
            new (ClaimTypes.Role, UserRoles.User),
            new (ClaimTypes.DateOfBirth, dob.ToString("yyyy-MM-dd")),
        ];
        
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "ToAuth"));

        httpContextAccessorMock.Setup(x => x.HttpContext)
            .Returns(new DefaultHttpContext { User = user });

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // Act
        var currentUser = userContext.GetCurrentUser();

        // Assert
        currentUser.Should().NotBeNull();
        currentUser.Id.Should().Be("99");
        currentUser.Email.Should().Be("test@email.com");
        currentUser.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
        currentUser.DateOfBirth.Should().Be(dob);
    }

    [Fact()]
    public void GetCurrentUser_WithNoUserContext_ThrowsInvalidOperationException()
    {
        // Arrange  
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

        httpContextAccessorMock.Setup(x => x.HttpContext)
            .Returns((HttpContext?)null);

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // Act
        Action act = () => userContext.GetCurrentUser();

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("User context not available");
    }
}