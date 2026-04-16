using ELibraryAPI.Application.Features.Queries.AppUserPermission.GetByIdAppUserPermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.AppUserPermission;

public sealed class GetByIdAppUserPermissionQueryValidator : AbstractValidator<GetByIdAppUserPermissionQueryRequest>
{
    public GetByIdAppUserPermissionQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
