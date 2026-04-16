using ELibraryAPI.Application.Features.Commands.Permission.UpdatePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Permission;

public sealed class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommandRequest>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Key).NotEmpty().MaximumLength(150);
    }
}
