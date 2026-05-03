using ELibraryAPI.Application.Features.Commands.CoverType.CreateCoverType;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.CoverType;

public sealed class CreateCoverTypeCommandValidator : AbstractValidator<CreateCoverTypeCommandRequest>
{
    public CreateCoverTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Cover type name is required.")
            .MaximumLength(50).WithMessage("Cover type name cannot exceed 50 characters.");
    }
}