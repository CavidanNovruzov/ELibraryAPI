using ELibraryAPI.Application.Features.Commands.RolePermission.DeleteRolePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RolePermission;

public sealed class DeleteRolePermissionCommandValidator : AbstractValidator<DeleteRolePermissionCommandRequest>
{
    public DeleteRolePermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
