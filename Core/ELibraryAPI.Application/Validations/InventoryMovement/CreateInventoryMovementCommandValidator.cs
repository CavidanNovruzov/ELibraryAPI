using ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.InventoryMovement;

public sealed class CreateInventoryMovementCommandValidator : AbstractValidator<CreateInventoryMovementCommandRequest>
{
    public CreateInventoryMovementCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        RuleFor(x => x.FromBranchId).NotEmpty();
        RuleFor(x => x.ToBranchId).NotEmpty()
            .NotEqual(x => x.FromBranchId).WithMessage("Source and destination branches cannot be the same.");
        RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
    }
}