using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Auth.AppUser.UpdateProfile;
namespace ELibraryAPI.Application.Validations.Auth.AppUser;

public sealed class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommandRequest>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.UserName)
            .NotEmpty().MinimumLength(3).MaximumLength(50)
            .Matches("^[a-zA-Z0-9._-]+$");
    }
}
