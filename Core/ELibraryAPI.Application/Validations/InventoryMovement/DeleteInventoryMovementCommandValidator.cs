using ELibraryAPI.Application.Features.Commands.InventoryMovement.DeleteInventoryMovement;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.InventoryMovement;

public sealed class DeleteInventoryMovementCommandValidator : AbstractValidator<DeleteInventoryMovementCommandRequest>
{
    public DeleteInventoryMovementCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
