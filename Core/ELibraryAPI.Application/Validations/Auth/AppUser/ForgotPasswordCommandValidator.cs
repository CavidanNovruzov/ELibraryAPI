using ELibraryAPI.Application.Features.Commands.Auth.ForgotPassword;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.Auth.AppUser;

public sealed class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommandRequest>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(256);
    }
}
