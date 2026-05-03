using ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.InventoryMovement;

public sealed class UpdateInventoryMovementCommandValidator : AbstractValidator<UpdateInventoryMovementCommandRequest>
{
    public UpdateInventoryMovementCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Movement type is required.")
            .MaximumLength(50);
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.")
            .MaximumLength(50);
    }
}