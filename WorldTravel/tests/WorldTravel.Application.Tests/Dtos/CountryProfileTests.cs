using AutoMapper;
using FluentAssertions;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using WorldTravel.Application.Countries.Commands.UpdateCountry;
using WorldTravel.Application.Dtos;
using WorldTravel.Domain.Entities;
using Xunit;

namespace WorldTravel.Application.Tests.Dtos;

public class CountryProfileTests
{
    private IMapper _mapper;

    public CountryProfileTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CountryProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact()]
    public void CreateMap_ForCountryToCountryDto_MapsCorrectly()
    {
        // Arrange
        var country = new Country
        {
            Id = "FR",
            Name = "Test Country",
            ContinentId = "EU",
            Description = "Test Description",
            Population = 1000000,
            NumberOfTourists = 10000
        };

        // Act
        var countryDto = _mapper.Map<CountryDto>(country);

        // Assert
        countryDto.Should().NotBeNull();
        countryDto.Id.Should().Be(country.Id);
        countryDto.Name.Should().Be(country.Name);
        countryDto.ContinentId.Should().Be(country.ContinentId);
        countryDto.Description.Should().Be(country.Description);
        countryDto.Population.Should().Be(country.Population);
        countryDto.NumberOfTourists.Should().Be(country.NumberOfTourists);
    }

    [Fact()]

    public void CreateMap_ForCreateCountryCommandToCountryDto_MapsCorrectly()
    {
        // Arrange
        var command = new CreateCountryCommand
        {
            Id = "FR",
            Name = "Test Country",
            ContinentId = "EU",
            Description = "Test Description",
            Population = 1000000,
            NumberOfTourists = 10000
        };

        // Act
        var country = _mapper.Map<Country>(command);

        // Assert
        country.Should().NotBeNull();
        country.Id.Should().Be(command.Id);
        country.Name.Should().Be(command.Name);
        country.ContinentId.Should().Be(command.ContinentId);
        country.Description.Should().Be(command.Description);
        country.Population.Should().Be(command.Population);
        country.NumberOfTourists.Should().Be(command.NumberOfTourists);
    }

    [Fact()]

    public void CreateMap_ForUpdateCountryCommandToCountryDto_MapsCorrectly()
    {
        // Arrange
        var command = new UpdateCountryCommand
        {
            Id = "FR",
            Description = "Test Description",
            Population = 1000000,
            NumberOfTourists = 10000
        };

        // Act
        var country = _mapper.Map<Country>(command);

        // Assert
        country.Should().NotBeNull();
        country.Id.Should().Be(command.Id);
        country.Description.Should().Be(command.Description);
        country.Population.Should().Be(command.Population);
        country.NumberOfTourists.Should().Be(command.NumberOfTourists);
    }
}