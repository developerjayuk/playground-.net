using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using Xunit;

namespace WorldTravel.Application.Tests.Countries.Commands.CreateCountry;

public class CreateCountryCommandHandlerTests
{
    [Fact()]
    public async Task Handle_ForValidCommand_ReturnsCreatedCountryId()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<CreateCountryCommandHandler>>();
        var mapperMock = new Mock<IMapper>();
        var countriesRepositoryMock = new Mock<ICountriesRepository>();
        var userContextMock = new Mock<IUserContext>();
        var currentUser = new CurrentUser("123", "email@test.com", [UserRoles.Owner], null);
        var command = new CreateCountryCommand();
        var country = new Country();

        mapperMock.Setup(m => m.Map<Country>(command)).Returns(country);

        countriesRepositoryMock
            .Setup(repo => repo.CreateAsync(It.IsAny<Country>()))
            .ReturnsAsync("IT");

        userContextMock.Setup(u => u.GetCurrentUser()).Returns(currentUser);

        var commandHandler = 
            new CreateCountryCommandHandler(loggerMock.Object, mapperMock.Object, countriesRepositoryMock.Object, userContextMock.Object);

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be("IT");
        country.CreatedById.Should().Be("123");
        countriesRepositoryMock.Verify(r => r.CreateAsync(country), Times.Once);
    }
}