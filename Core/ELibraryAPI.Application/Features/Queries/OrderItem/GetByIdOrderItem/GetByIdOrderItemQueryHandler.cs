using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderItem.GetByIdOrderItem;

public sealed class GetByIdOrderItemQueryHandler : IRequestHandler<GetByIdOrderItemQueryRequest, Result<GetByIdOrderItemQueryResponse>>
{
    public Task<Result<GetByIdOrderItemQueryResponse>> Handle(GetByIdOrderItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
