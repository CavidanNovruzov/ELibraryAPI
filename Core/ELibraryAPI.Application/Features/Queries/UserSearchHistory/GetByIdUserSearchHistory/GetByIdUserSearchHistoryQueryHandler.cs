using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetByIdUserSearchHistory;

public sealed class GetByIdUserSearchHistoryQueryHandler : IRequestHandler<GetByIdUserSearchHistoryQueryRequest, Result<GetByIdUserSearchHistoryQueryResponse>>
{
    public Task<Result<GetByIdUserSearchHistoryQueryResponse>> Handle(GetByIdUserSearchHistoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
