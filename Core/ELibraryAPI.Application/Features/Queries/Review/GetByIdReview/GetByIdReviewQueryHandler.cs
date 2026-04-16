using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Review.GetByIdReview;

public sealed class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQueryRequest, Result<GetByIdReviewQueryResponse>>
{
    public Task<Result<GetByIdReviewQueryResponse>> Handle(GetByIdReviewQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
