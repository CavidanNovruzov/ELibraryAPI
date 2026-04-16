using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderItem.GetAllOrderItem;

public sealed class GetAllOrderItemQueryHandler : IRequestHandler<GetAllOrderItemQueryRequest, Result<GetAllOrderItemQueryResponse>>
{
    public Task<Result<GetAllOrderItemQueryResponse>> Handle(GetAllOrderItemQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
