using ELibraryAPI.Application.Features.Commands.Permission.CreatePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Permission;

public sealed class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommandRequest>
{
    public CreatePermissionCommandValidator()
    {
        RuleFor(x => x.Key).NotEmpty().MaximumLength(150);
    }
}
