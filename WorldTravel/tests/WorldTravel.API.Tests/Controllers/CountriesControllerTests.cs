using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using System.Net.Http.Json;
using WorldTravel.Application.Dtos;
using WorldTravel.Domain.Entities;
using WorldTravel.Domain.Repositories;
using Xunit;

namespace WorldTravel.API.Tests.Controllers;

public class CountriesControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly Mock<ICountriesRepository> _countriesRepositoryMock;
    private readonly WebApplicationFactory<Program> _factory;

    public CountriesControllerTests(WebApplicationFactory<Program> factory)
    {
        _countriesRepositoryMock = new Mock<ICountriesRepository>();
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Configure any test-specific services here
                // For example, you can replace the database context with an in-memory database
                services.AddSingleton<IPolicyEvaluator, TestPolicyEvaluator>();
                services.Replace(ServiceDescriptor.Scoped(typeof(ICountriesRepository), _ => _countriesRepositoryMock.Object));
            });
        });
    }

    [Fact()]
    public async Task GetAll_ForValidRequest_Returns200Ok()
    {
        // endpoint doesn't require authorization

        // Arrange
        var client = _factory.CreateClient();
        var requestUri = "/api/countries";

        // Act
        var response = await client.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

    [Fact()]
    public async Task GetAll_ForInvalidRequest_Returns400BadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();
        var requestUri = "/api/countries?direction=abc";

        // Act
        var response = await client.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }

    [Fact()]
    public async Task GetById_ForInvalidId_Returns404NotFound()
    {
        // Arrange
        var id = "4593";
        var client = _factory.CreateClient();
        var requestUri = $"/api/countries/{id}";

        _countriesRepositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((Country?)null);

        // Act
        var response = await client.GetAsync(requestUri);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Fact()]
    public async Task GetById_ForValidId_Returns200Ok()
    {
        // Arrange
        var id = "008";
        var client = _factory.CreateClient();
        var requestUri = $"/api/countries/{id}";

        var country = new Country
        {
            Id = id,
            Name = "Fakeland",
            Description = "Beautiful country in Europe",
            Population = 60000000,
            NumberOfTourists = 100000000
        };

        _countriesRepositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync(country);

        // Act
        var response = await client.GetAsync(requestUri);
        var countryResponse = await response.Content.ReadFromJsonAsync<CountryDto>();

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        countryResponse.Should().NotBeNull();
        countryResponse!.Id.Should().Be("008");
        countryResponse!.Name.Should().Be("Fakeland");
    }
}
