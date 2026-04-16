using ELibraryAPI.Application.Features.Queries.Author.GetByIdAuthor;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Author;

public sealed class GetByIdAuthorQueryValidator : AbstractValidator<GetByIdAuthorQueryRequest>
{
    public GetByIdAuthorQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
