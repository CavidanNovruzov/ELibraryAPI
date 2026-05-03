using ELibraryAPI.Application.Features.Commands.BranchWorkHours.DeleteBranchWorkHours;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BranchWorkHours;

public sealed class DeleteBranchWorkHoursCommandValidator : AbstractValidator<DeleteBranchWorkHoursCommandRequest>
{
    public DeleteBranchWorkHoursCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
