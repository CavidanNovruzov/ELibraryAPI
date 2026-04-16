using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.DeleteReview;

public sealed class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, Result>
{
    public Task<Result> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
