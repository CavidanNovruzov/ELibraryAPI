using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.UpdateReview;

public sealed class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, Result<UpdateReviewCommandResponse>>
{
    public Task<Result<UpdateReviewCommandResponse>> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
