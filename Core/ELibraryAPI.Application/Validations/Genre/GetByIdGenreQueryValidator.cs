using ELibraryAPI.Application.Features.Queries.Genre.GetByIdGenre;
using FluentValidation;


namespace ELibraryAPI.Application.Validations.Genre;

public sealed class GetByIdGenreQueryValidator : AbstractValidator<GetByIdGenreQueryRequest>
{
    public GetByIdGenreQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Genre ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Please provide a valid Genre ID.");
    }
}
