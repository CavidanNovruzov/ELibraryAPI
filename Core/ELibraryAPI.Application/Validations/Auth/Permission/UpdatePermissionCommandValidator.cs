using ELibraryAPI.Application.Features.Commands.Auth.Roles.Permission.UpdatePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Permission;

public sealed class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommandRequest>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);

        RuleFor(x => x.Key).NotEmpty().MaximumLength(150);
    }
}
