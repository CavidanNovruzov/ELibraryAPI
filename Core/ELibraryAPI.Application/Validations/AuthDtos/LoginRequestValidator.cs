using ELibraryAPI.Application.Dtos.Auth;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AuthDtos;

public sealed class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Login)
            .NotEmpty()
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(128);
    }
}

