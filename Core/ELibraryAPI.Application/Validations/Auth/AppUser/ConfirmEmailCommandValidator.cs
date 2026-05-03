using ELibraryAPI.Application.Features.Commands.Auth.AppUser.ConfirmEmail;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Auth.AppUser;

public sealed class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommandRequest>
{
    public ConfirmEmailCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.Token)
            .NotEmpty()
            .MaximumLength(2048);
    }
}

