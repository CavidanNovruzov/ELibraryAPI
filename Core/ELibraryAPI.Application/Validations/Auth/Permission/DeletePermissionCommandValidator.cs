using ELibraryAPI.Application.Features.Commands.Permission.DeletePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Permission;

public sealed class DeletePermissionCommandValidator : AbstractValidator<DeletePermissionCommandRequest>
{
    public DeletePermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
