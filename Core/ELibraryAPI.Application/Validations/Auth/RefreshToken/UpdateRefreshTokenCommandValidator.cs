using ELibraryAPI.Application.Features.Commands.RefreshToken.UpdateRefreshToken;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RefreshToken;

public sealed class UpdateRefreshTokenCommandValidator : AbstractValidator<UpdateRefreshTokenCommandRequest>
{
    public UpdateRefreshTokenCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.ExpiresAt).NotEmpty();
        RuleFor(x => x.TokenHash).NotEmpty().MaximumLength(512);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
