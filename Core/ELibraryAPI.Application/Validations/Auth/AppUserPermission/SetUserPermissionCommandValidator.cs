using FluentValidation;

namespace ELibraryAPI.Application.Features.Commands.Auth.Roles.AppUserPermission;

public class SetUserPermissionCommandValidator : AbstractValidator<SetUserPermissionCommandRequest>
{
    public SetUserPermissionCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.");

        RuleFor(x => x.PermissionIds)
            .NotEmpty()
            .WithMessage("At least one permission must be selected.")
            .Must(p => p != null && p.Count > 0)
            .WithMessage("The permission list cannot be empty.");

        // Siyahının daxilindəki hər bir ID-ni yoxlayırıq
        RuleForEach(x => x.PermissionIds)
            .GreaterThan(0)
            .WithMessage("Invalid Permission ID found.");
    }
}