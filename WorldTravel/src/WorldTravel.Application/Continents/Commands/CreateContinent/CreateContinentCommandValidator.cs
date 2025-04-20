using FluentValidation;

namespace WorldTravel.Application.Continents.Commands.CreateContinent;

public class CreateContinentCommandValidator : AbstractValidator<CreateContinentCommand>
{
    public CreateContinentCommandValidator()
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
    }
}
