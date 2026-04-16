using ELibraryAPI.Application.Features.Commands.Branch.CreateBranch;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Branch;

public sealed class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommandRequest>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.Location).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
    }
}
