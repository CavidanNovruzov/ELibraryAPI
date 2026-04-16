using ELibraryAPI.Application.Features.Queries.RolePermission.GetByIdRolePermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.RolePermission;

public sealed class GetByIdRolePermissionQueryValidator : AbstractValidator<GetByIdRolePermissionQueryRequest>
{
    public GetByIdRolePermissionQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
