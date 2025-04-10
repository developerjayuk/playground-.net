using FluentValidation;

namespace WorldTravel.Application.WorldTravel.Commands.CreateCountry;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .Length(2)
            .WithMessage("Id must be 2 characters ISO code.");
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");
        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");
        RuleFor(c => c.ContinentId)
            .NotEmpty()
            .Length(2)
            .WithMessage("ContinentId must be 2 characters in length.");
    }
}
