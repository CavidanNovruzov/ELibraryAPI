using ELibraryAPI.Application.Dtos.Auth;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AuthDtos;

public sealed class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .MaximumLength(64)
            .Must(static id => Guid.TryParse(id, out _))
            .WithMessage("UserId düzgün GUID formatında olmalıdır.");

        RuleFor(x => x.Token)
            .NotEmpty()
            .MaximumLength(2048);
    }
}

