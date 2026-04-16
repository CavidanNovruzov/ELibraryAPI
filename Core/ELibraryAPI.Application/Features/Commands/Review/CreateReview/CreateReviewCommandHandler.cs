using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.CreateReview;

public sealed class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, Result<CreateReviewCommandResponse>>
{
    public Task<Result<CreateReviewCommandResponse>> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
