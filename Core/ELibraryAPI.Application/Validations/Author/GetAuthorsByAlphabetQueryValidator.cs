using ELibraryAPI.Application.Features.Queries.Author.GetAuthorsByAlphabet;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Author;

public sealed class GetAuthorsByAlphabetQueryValidator : AbstractValidator<GetAuthorsByAlphabetQueryRequest>
{
    public GetAuthorsByAlphabetQueryValidator()
    {
        RuleFor(x => x.Letter)
            .NotEmpty()
            .Must(char.IsLetter).WithMessage("Please provide a valid letter.");
    }
}
