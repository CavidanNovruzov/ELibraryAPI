using ELibraryAPI.Application.Dtos.Auth;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AuthDtos;

public sealed class RegistrRequestValidator : AbstractValidator<RegistrRequest>
{
    public RegistrRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.UserName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(256);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(128);
    }
}

