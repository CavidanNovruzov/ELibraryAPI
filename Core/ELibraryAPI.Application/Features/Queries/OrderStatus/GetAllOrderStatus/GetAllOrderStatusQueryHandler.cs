using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetAllOrderStatus;

public sealed class GetAllOrderStatusQueryHandler : IRequestHandler<GetAllOrderStatusQueryRequest, Result<GetAllOrderStatusQueryResponse>>
{
    public Task<Result<GetAllOrderStatusQueryResponse>> Handle(GetAllOrderStatusQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
