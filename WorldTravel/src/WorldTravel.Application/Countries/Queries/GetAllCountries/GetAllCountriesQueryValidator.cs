using FluentValidation;
using WorldTravel.Application.Common;
using WorldTravel.Domain.Entities;

namespace WorldTravel.Application.Countries.Queries.GetAllCountries;

public class GetAllCountriesQueryValidator : AbstractValidator<GetAllCountriesQuery>
{
    private int[] pageSizes = [5, 10, 20, 50, 100];
    private string[] sortColumns = [nameof(Country.Name), nameof(Country.ContinentId)];

    public GetAllCountriesQueryValidator()
    {
        RuleFor(r => r.Page).GreaterThan(0).WithMessage("Page number query string (?page=) must be greater than 0");

        RuleFor(r => r.Size)
            .Must(size => pageSizes.Contains(size))
            .WithMessage($"Page size query string (?size=) must be one of the following values: {string.Join(", ", pageSizes)}");

        RuleFor(r => r.SearchPhrase)
            .MaximumLength(50)
            .WithMessage("Search phrase query string (?search=) must be less than 50 characters long");

        RuleFor(r => r.SortBy)
            .Must(c => sortColumns.Contains(c))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort column query string (?sortcolumn=) is optional or must be one of the following values: {string.Join(", ", sortColumns)}");

        RuleFor(r => r.Direction)
            .IsInEnum()
            .WithMessage("Sort direction query string (?direction=) must be one of the following values: 'Asc', 'Desc'");
    }
}
