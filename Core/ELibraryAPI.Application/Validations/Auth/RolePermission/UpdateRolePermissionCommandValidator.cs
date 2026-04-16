using ELibraryAPI.Application.Features.Commands.RolePermission.UpdateRolePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RolePermission;

public sealed class UpdateRolePermissionCommandValidator : AbstractValidator<UpdateRolePermissionCommandRequest>
{
    public UpdateRolePermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.PermissionId).GreaterThan(0);
        RuleFor(x => x.RoleId).NotEmpty();
    }
}
