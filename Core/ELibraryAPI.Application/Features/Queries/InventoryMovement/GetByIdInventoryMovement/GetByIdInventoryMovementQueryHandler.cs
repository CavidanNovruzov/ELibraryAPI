using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetByIdInventoryMovement;

public sealed class GetByIdInventoryMovementQueryHandler : IRequestHandler<GetByIdInventoryMovementQueryRequest, Result<GetByIdInventoryMovementQueryResponse>>
{
    public Task<Result<GetByIdInventoryMovementQueryResponse>> Handle(GetByIdInventoryMovementQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
