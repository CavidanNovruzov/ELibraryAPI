using ELibraryAPI.Application.Features.Queries.ProductAuthor.GetByIdProductAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.ProductAuthor;

public sealed class GetByIdProductAuthorQueryValidator : AbstractValidator<GetByIdProductAuthorQueryRequest>
{
    public GetByIdProductAuthorQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
