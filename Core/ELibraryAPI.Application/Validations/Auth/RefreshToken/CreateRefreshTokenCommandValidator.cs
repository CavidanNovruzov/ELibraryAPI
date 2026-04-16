using ELibraryAPI.Application.Features.Commands.RefreshToken.CreateRefreshToken;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RefreshToken;

public sealed class CreateRefreshTokenCommandValidator : AbstractValidator<CreateRefreshTokenCommandRequest>
{
    public CreateRefreshTokenCommandValidator()
    {
        RuleFor(x => x.ExpiresAt).NotEmpty();
        RuleFor(x => x.TokenHash).NotEmpty().MaximumLength(512);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
