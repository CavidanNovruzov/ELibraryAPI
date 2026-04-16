using ELibraryAPI.Application.Features.Queries.Tag.GetByIdTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Tag;

public sealed class GetByIdTagQueryValidator : AbstractValidator<GetByIdTagQueryRequest>
{
    public GetByIdTagQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
