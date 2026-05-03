using ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;
using FluentValidation;


namespace ELibraryAPI.Application.Validations.Author;

public sealed class GetAllAuthorQueryValidator : AbstractValidator<GetAllAuthorQueryRequest>
{
    public GetAllAuthorQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}
