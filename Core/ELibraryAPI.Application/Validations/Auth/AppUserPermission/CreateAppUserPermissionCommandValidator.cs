using ELibraryAPI.Application.Features.Commands.AppUserPermission.CreateAppUserPermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.AppUserPermission;

public sealed class CreateAppUserPermissionCommandValidator : AbstractValidator<CreateAppUserPermissionCommandRequest>
{
    public CreateAppUserPermissionCommandValidator()
    {
        RuleFor(x => x.PermissionId).GreaterThan(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
