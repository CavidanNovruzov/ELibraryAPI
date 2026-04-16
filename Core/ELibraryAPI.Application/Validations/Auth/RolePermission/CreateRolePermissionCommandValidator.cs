using ELibraryAPI.Application.Features.Commands.RolePermission.CreateRolePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RolePermission;

public sealed class CreateRolePermissionCommandValidator : AbstractValidator<CreateRolePermissionCommandRequest>
{
    public CreateRolePermissionCommandValidator()
    {
        RuleFor(x => x.PermissionId).GreaterThan(0);
        RuleFor(x => x.RoleId).NotEmpty();
    }
}
