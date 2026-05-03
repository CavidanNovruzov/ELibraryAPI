using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetAllUserSearchHistory;

public sealed class GetAllUserSearchHistoryQueryHandler : IRequestHandler<GetAllUserSearchHistoryQueryRequest, Result<GetAllUserSearchHistoryQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUserSearchHistoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllUserSearchHistoryQueryResponse>> Handle(GetAllUserSearchHistoryQueryRequest request, CancellationToken cancellationToken)
    {
        var histories = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.UserSearchHistory, Guid>()
            .GetAll(tracking: false)
            .OrderByDescending(x => x.CreatedDate)
            .Select(x => new UserSearchHistoryListDto(
                x.Id,
                x.UserId,
                x.SearchQuery,
                x.CreatedDate
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllUserSearchHistoryQueryResponse>.Success(new GetAllUserSearchHistoryQueryResponse(histories));
    }
}