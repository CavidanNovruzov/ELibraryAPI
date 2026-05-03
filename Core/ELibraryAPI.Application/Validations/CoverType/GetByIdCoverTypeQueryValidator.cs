using ELibraryAPI.Application.Features.Queries.CoverType.GetByIdCoverType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.CoverType;

public sealed class GetByIdCoverTypeQueryValidator : AbstractValidator<GetByIdCoverTypeQueryRequest>
{
    public GetByIdCoverTypeQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Cover Type ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Please provide a valid ID.");
    }
}
