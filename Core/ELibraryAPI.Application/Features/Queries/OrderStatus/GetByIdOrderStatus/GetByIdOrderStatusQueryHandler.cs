using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.OrderStatus.GetByIdOrderStatus;

public sealed class GetByIdOrderStatusQueryHandler : IRequestHandler<GetByIdOrderStatusQueryRequest, Result<GetByIdOrderStatusQueryResponse>>
{
    public Task<Result<GetByIdOrderStatusQueryResponse>> Handle(GetByIdOrderStatusQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
