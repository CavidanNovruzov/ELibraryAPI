using ELibraryAPI.Application.Features.Commands.AppUserPermission.UpdateAppUserPermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AppUserPermission;

public sealed class UpdateAppUserPermissionCommandValidator : AbstractValidator<UpdateAppUserPermissionCommandRequest>
{
    public UpdateAppUserPermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.PermissionId).GreaterThan(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
