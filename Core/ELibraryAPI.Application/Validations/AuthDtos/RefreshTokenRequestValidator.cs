using ELibraryAPI.Application.Dtos.Auth;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AuthDtos;

public sealed class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .MaximumLength(1024);
    }
}

