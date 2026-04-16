using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Order.GetAllOrder;

public sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, Result<GetAllOrderQueryResponse>>
{
    public Task<Result<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
