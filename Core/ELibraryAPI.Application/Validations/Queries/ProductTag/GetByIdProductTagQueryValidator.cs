using ELibraryAPI.Application.Features.Queries.ProductTag.GetByIdProductTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.ProductTag;

public sealed class GetByIdProductTagQueryValidator : AbstractValidator<GetByIdProductTagQueryRequest>
{
    public GetByIdProductTagQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
