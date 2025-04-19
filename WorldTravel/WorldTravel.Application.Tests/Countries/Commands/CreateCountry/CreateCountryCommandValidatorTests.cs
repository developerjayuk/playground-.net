using FluentValidation.TestHelper;
using WorldTravel.Application.Countries.Commands.CreateCountry;
using Xunit;

namespace WorldTravel.Application.Tests.Countries.Commands.CreateCountry;

public class CreateCountryCommandValidatorTests
{
    [Fact()]
    public void CreateCountryCommandValidatorTest()
    {
        // Arrange
        CreateCountryCommand command = new()
        {
            Id = "FR",
            Name = "Test Country",
            ContinentId = "EU",
            Description = "Test Description",
            Population = 1000000,
            NumberOfTourists = 10000
        };

        var validator = new CreateCountryCommandValidator();

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        // Arrange
        CreateCountryCommand command = new()
        {
            Id = "123",
            Name = "Test Country",
            ContinentId = "EUR",
            Description = "Test Description",
            Population = 45556,
            NumberOfTourists = -1
        };

        var validator = new CreateCountryCommandValidator();

        // Act
        var result = validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(r => r.Id);
        result.ShouldHaveValidationErrorFor(r => r.ContinentId);
        result.ShouldHaveValidationErrorFor(r => r.NumberOfTourists);
    }
}