using FluentValidation;

namespace WorldTravel.Application.WorldTravel.Commands.UpdateCountry;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id is required.")
            .Length(2)
            .WithMessage("Id must be 2 characters ISO code.");
        RuleFor(c => c.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");
    }
}
