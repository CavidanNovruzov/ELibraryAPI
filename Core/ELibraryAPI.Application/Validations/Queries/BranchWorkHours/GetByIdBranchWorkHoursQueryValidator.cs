using ELibraryAPI.Application.Features.Queries.BranchWorkHours.GetByIdBranchWorkHours;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.BranchWorkHours;

public sealed class GetByIdBranchWorkHoursQueryValidator : AbstractValidator<GetByIdBranchWorkHoursQueryRequest>
{
    public GetByIdBranchWorkHoursQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
