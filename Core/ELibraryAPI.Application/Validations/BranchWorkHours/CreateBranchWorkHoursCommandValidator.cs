using ELibraryAPI.Application.Features.Commands.BranchWorkHours.CreateBranchWorkHours;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BranchWorkHours;

public sealed class CreateBranchWorkHoursCommandValidator : AbstractValidator<CreateBranchWorkHoursCommandRequest>
{
    public CreateBranchWorkHoursCommandValidator()
    {
        RuleFor(x => x.BranchId).NotEmpty();
        RuleFor(x => x.CloseTime).NotEmpty().GreaterThan(x => x.OpenTime);
        RuleFor(x => x.Day).IsInEnum();
        RuleFor(x => x.OpenTime).NotEmpty();
    }
}
