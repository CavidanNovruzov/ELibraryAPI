using ELibraryAPI.Application.Features.Queries.RefreshToken.GetByIdRefreshToken;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.RefreshToken;

public sealed class GetByIdRefreshTokenQueryValidator : AbstractValidator<GetByIdRefreshTokenQueryRequest>
{
    public GetByIdRefreshTokenQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
