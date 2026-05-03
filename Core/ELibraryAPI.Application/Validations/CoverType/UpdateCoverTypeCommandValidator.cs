using ELibraryAPI.Application.Features.Commands.CoverType.UpdateCoverType;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.CoverType;

public sealed class UpdateCoverTypeCommandValidator : AbstractValidator<UpdateCoverTypeCommandRequest>
{
    public UpdateCoverTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}