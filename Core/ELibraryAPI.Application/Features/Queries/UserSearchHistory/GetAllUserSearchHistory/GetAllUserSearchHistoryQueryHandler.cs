using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetAllUserSearchHistory;

public sealed class GetAllUserSearchHistoryQueryHandler : IRequestHandler<GetAllUserSearchHistoryQueryRequest, Result<GetAllUserSearchHistoryQueryResponse>>
{
    public Task<Result<GetAllUserSearchHistoryQueryResponse>> Handle(GetAllUserSearchHistoryQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
