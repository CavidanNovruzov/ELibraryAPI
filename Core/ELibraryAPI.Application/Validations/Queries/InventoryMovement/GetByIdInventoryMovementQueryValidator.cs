using ELibraryAPI.Application.Features.Queries.InventoryMovement.GetByIdInventoryMovement;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.InventoryMovement;

public sealed class GetByIdInventoryMovementQueryValidator : AbstractValidator<GetByIdInventoryMovementQueryRequest>
{
    public GetByIdInventoryMovementQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
