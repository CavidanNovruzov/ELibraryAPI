using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Review.GetAllReview;

public sealed class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQueryRequest, Result<GetAllReviewQueryResponse>>
{
    public Task<Result<GetAllReviewQueryResponse>> Handle(GetAllReviewQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
