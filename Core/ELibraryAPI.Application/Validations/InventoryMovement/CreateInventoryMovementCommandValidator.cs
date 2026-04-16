using ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.InventoryMovement;

public sealed class CreateInventoryMovementCommandValidator : AbstractValidator<CreateInventoryMovementCommandRequest>
{
    public CreateInventoryMovementCommandValidator()
    {
        RuleFor(x => x.FromBranchId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.ToBranchId).NotEmpty().NotEqual(x => x.FromBranchId);
        RuleFor(x => x.Type).NotEmpty().MaximumLength(50);
    }
}
