namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;

public sealed record GetAllInventoryMovementQueryResponse(
    List<InventoryMovementListDto> Movements
);

public sealed record InventoryMovementListDto(
    Guid Id,
    Guid ProductId,
    string ProductTitle,
    Guid FromBranchId,
    string FromBranchName,
    Guid ToBranchId,
    string ToBranchName,
    int Quantity,
    string Type,
    DateTime CreatedDate
);
