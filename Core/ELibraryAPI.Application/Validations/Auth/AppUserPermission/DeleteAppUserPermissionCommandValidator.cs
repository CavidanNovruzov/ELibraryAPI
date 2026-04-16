using ELibraryAPI.Application.Features.Commands.AppUserPermission.DeleteAppUserPermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AppUserPermission;

public sealed class DeleteAppUserPermissionCommandValidator : AbstractValidator<DeleteAppUserPermissionCommandRequest>
{
    public DeleteAppUserPermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
