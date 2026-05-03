using ELibraryAPI.Application.Features.Commands.Auth.AppUser.ChangePassword;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibraryAPI.Application.Validations.Auth.AppUser
{
    public sealed class ChangePasswordCommandValidator :AbstractValidator<ChangePasswordCommandRequest>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(8).MaximumLength(128);
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(128)
                .NotEqual(x => x.CurrentPassword);
        }
    }
}
