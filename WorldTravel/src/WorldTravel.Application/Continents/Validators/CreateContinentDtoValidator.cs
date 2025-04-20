using FluentValidation;
using WorldTravel.Application.Dtos;

namespace WorldTravel.Application.Continents.Validators;

public class CreateContinentDtoValidator : AbstractValidator<CreateContinentDto>
{
    public CreateContinentDtoValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id is required")
            .Length(2)
            .WithMessage("Id must be 2 characters ISO code");
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters");
        RuleFor(c => c.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters");
    }
}
