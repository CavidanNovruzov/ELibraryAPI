using ELibraryAPI.Application.Features.Queries.Branch.GetByIdBranch;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Branch;

public sealed class GetByIdBranchQueryValidator : AbstractValidator<GetByIdBranchQueryRequest>
{
    public GetByIdBranchQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
