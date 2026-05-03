using ELibraryAPI.Application.Features.Commands.Auth.ResetPassword;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.Auth.AppUser;

public sealed class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommandRequest>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Token).NotEmpty();
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8).MaximumLength(128);
    }
}
