using ELibraryAPI.Application.Features.Commands.BranchWorkHours.UpdateBranchWorkHours;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BranchWorkHours;

public sealed class UpdateBranchWorkHoursCommandValidator : AbstractValidator<UpdateBranchWorkHoursCommandRequest>
{
    public UpdateBranchWorkHoursCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.CloseTime).NotEmpty().GreaterThan(x => x.OpenTime);
        RuleFor(x => x.Day).IsInEnum();
        RuleFor(x => x.OpenTime).NotEmpty();
    }
}
