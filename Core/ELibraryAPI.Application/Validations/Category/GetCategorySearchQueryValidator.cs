using ELibraryAPI.Application.Features.Queries.Category.GetCategorySearch;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.Category;

public sealed class GetCategorySearchQueryValidator : AbstractValidator<GetCategorySearchQueryRequest>
{
    public GetCategorySearchQueryValidator()
    {
        RuleFor(x => x.SearchTerm)
            .NotEmpty().WithMessage("Search term cannot be empty.")
            .MinimumLength(2).WithMessage("Search term must be at least 2 characters.");

        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).InclusiveBetween(1, 50);
    }
}
