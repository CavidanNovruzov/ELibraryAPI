using ELibraryAPI.Application.Features.Queries.Permission.GetByIdPermission;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Permission;

public sealed class GetByIdPermissionQueryValidator : AbstractValidator<GetByIdPermissionQueryRequest>
{
    public GetByIdPermissionQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
