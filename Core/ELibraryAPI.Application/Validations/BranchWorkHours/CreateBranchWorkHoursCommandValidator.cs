using ELibraryAPI.Application.Features.Commands.BranchWorkHours.CreateBranchWorkHours;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.BranchWorkHours
{
    public sealed class CreateBranchWorkHoursCommandValidator : AbstractValidator<CreateBranchWorkHoursCommandRequest>
    {
        public CreateBranchWorkHoursCommandValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch must be selected.")
                .NotEqual(Guid.Empty).WithMessage("Please enter a valid Branch ID.");

            RuleFor(x => x.Day)
                .IsInEnum().WithMessage("Please select a valid day of the week.");

            RuleFor(x => x.OpenTime)
                .NotEmpty().WithMessage("Opening time is required.");

            RuleFor(x => x.CloseTime)
                .NotEmpty().WithMessage("Closing time is required.");

            RuleFor(x => x)
                .Must(x => x.CloseTime > x.OpenTime)
                .WithMessage("Closing time must be later than opening time.")
                .When(x => x.OpenTime != default && x.CloseTime != default);

            RuleFor(x => x.OpenTime)
                .Must(t => t.TotalHours >= 0 && t.TotalHours < 24)
                .WithMessage("Opening time must be between 00:00 and 23:59.");

            RuleFor(x => x.CloseTime)
                .Must(t => t.TotalHours >= 0 && t.TotalHours < 24)
                .WithMessage("Closing time must be between 00:00 and 23:59.");
        }
    }
}