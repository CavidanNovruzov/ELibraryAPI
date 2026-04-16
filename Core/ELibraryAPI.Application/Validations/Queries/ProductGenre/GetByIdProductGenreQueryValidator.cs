using ELibraryAPI.Application.Features.Queries.ProductGenre.GetByIdProductGenre;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.ProductGenre;

public sealed class GetByIdProductGenreQueryValidator : AbstractValidator<GetByIdProductGenreQueryRequest>
{
    public GetByIdProductGenreQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
