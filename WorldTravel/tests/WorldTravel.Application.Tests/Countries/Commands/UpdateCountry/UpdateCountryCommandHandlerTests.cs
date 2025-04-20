using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using WorldTravel.Application.Countries.Commands.UpdateCountry;
using WorldTravel.Application.Users;
using WorldTravel.Domain.Constants;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Exceptions;
using WorldTravel.Domain.Interface;
using WorldTravel.Domain.Repositories;
using Xunit;

namespace WorldTravel.Application.Tests.Countries.Commands.UpdateCountry;

public class UpdateCountryCommandHandlerTests
{
    private readonly Mock<ILogger<UpdateCountryCommandHandler>> _loggerMock;
    private readonly Mock<ICountriesRepository> _countriesRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ICountryAuthorizationService> _countryAuthServiceMock;
    private readonly UpdateCountryCommandHandler _handler;


    public UpdateCountryCommandHandlerTests()
    {
        _loggerMock = new Mock<ILogger<UpdateCountryCommandHandler>>();
        _countriesRepositoryMock = new Mock<ICountriesRepository>();
        _mapperMock = new Mock<IMapper>();
        _countryAuthServiceMock = new Mock<ICountryAuthorizationService>();

        _handler = new UpdateCountryCommandHandler(
            _loggerMock.Object,
            _mapperMock.Object,
            _countriesRepositoryMock.Object,
            _countryAuthServiceMock.Object
        );
    }


    [Fact()]
    public async Task Handle_ForValidRequest_ShouldUpdateCountry()
    {
        // Arrange
        var countryId = "IT";
        var command = new UpdateCountryCommand
        {
            Id = countryId,
            Description = "Beautiful country in Europe",
            Population = 60000000,
            NumberOfTourists = 100000000
        };

        var country = new Country
        {
            Id = countryId,
            Description = "Old description",
            Population = 50000000,
            NumberOfTourists = 80000000
        };

        _countriesRepositoryMock
            .Setup(repo => repo.GetByIdAsync(countryId))
            .ReturnsAsync(country);

        _countryAuthServiceMock.Setup(auth => auth.Authorize(country, ResourceOperation.Update))
            .Returns(true);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _countriesRepositoryMock
            .Verify(r => r.GetByIdAsync(countryId), Times.Once);
        _mapperMock.Verify(m => m.Map(command, country), Times.Once);
    }

    [Fact()]
    public async Task Handle_ForNonExistingCountry_ShouldThrowNotFoundException()
    {
        // Arrange
        var countryId = "IT";
        var command = new UpdateCountryCommand
        {
            Id = countryId,
            Description = "Beautiful country in Europe",
        };

        _countriesRepositoryMock
            .Setup(repo => repo.GetByIdAsync(countryId))
            .ReturnsAsync((Country?)null);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"Country with id: {countryId} not found");


    }

    [Fact()]
    public async Task Handle_ForNonAuthUser_ShouldThrowForbidException()
    {
        // Arrange
        var countryId = "IT";
        var command = new UpdateCountryCommand
        {
            Id = countryId,
            Description = "Beautiful country in Europe",
        };

        var country = new Country
        {
            Id = countryId,
            Description = "Old description",
        };

        _countriesRepositoryMock
            .Setup(r => r.GetByIdAsync(countryId))
            .ReturnsAsync(country);

        _countryAuthServiceMock
            .Setup(a => a.Authorize(country, ResourceOperation.Update))
            .Returns(false);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ForbidException>();
    }
}