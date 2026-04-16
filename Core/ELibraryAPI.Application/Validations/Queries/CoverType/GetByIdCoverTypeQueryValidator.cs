using ELibraryAPI.Application.Features.Queries.CoverType.GetByIdCoverType;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.CoverType;

public sealed class GetByIdCoverTypeQueryValidator : AbstractValidator<GetByIdCoverTypeQueryRequest>
{
    public GetByIdCoverTypeQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
