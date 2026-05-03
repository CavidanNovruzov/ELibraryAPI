using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Branch.CreateBranch;

namespace ELibraryAPI.Application.Validations.Branch;

public sealed class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommandRequest>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Branch name is required.")
            .MaximumLength(150).WithMessage("Branch name cannot exceed 150 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?[0-9\s\-]{7,20}$").WithMessage("Invalid phone number format.");
    }
}