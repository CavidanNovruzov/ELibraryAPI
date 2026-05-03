using ELibraryAPI.Application.Features.Commands.Auth.Roles.RolePermission;
using FluentValidation;

public class SetRolePermissionsCommandValidator : AbstractValidator<SetRolePermissionsCommandRequest>
{
    public SetRolePermissionsCommandValidator()
    {
        RuleFor(x => x.RoleId).NotEmpty();
        RuleFor(x => x.PermissionIds).NotEmpty();
    }
}