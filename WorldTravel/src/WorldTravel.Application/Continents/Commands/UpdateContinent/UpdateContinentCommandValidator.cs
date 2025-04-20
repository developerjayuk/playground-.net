using FluentValidation;

namespace WorldTravel.Application.Continents.Commands.UpdateContinent;

public class UpdateContinentCommandValidator : AbstractValidator<UpdateContinentCommand>
{
    public UpdateContinentCommandValidator()
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
