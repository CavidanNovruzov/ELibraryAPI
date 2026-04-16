using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;

public sealed class GetAllInventoryMovementQueryHandler : IRequestHandler<GetAllInventoryMovementQueryRequest, Result<GetAllInventoryMovementQueryResponse>>
{
    public Task<Result<GetAllInventoryMovementQueryResponse>> Handle(GetAllInventoryMovementQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
