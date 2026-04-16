using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Order.GetByIdOrder;

public sealed class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, Result<GetByIdOrderQueryResponse>>
{
    public Task<Result<GetByIdOrderQueryResponse>> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
