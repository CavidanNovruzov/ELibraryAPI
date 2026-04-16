using ELibraryAPI.Application.Features.Commands.Branch.UpdateBranch;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Branch;

public sealed class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommandRequest>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Location).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
    }
}
