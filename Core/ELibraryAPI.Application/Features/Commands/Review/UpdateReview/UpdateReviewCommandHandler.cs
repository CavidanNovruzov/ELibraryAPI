using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.UpdateReview;

public sealed class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, Result<UpdateReviewCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateReviewCommandResponse>> Handle(UpdateReviewCommandRequest request, CancellationToken ct)
    {
        var reviewReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();

        var review = await reviewReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (review == null)
            return Result<UpdateReviewCommandResponse>.Failure("Review not found.");

        if (review.UserId != request.UserId)
            return Result<UpdateReviewCommandResponse>.Failure("You are not authorized to update this review.");

        if (request.Rating < 1 || request.Rating > 5)
            return Result<UpdateReviewCommandResponse>.Failure("Rating must be between 1 and 5.");

        _mapper.Map(request, review);

        review.IsApproved = false;

        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateReviewCommandResponse>.Success(
            new UpdateReviewCommandResponse(review.Id),
            "Review updated and sent for re-approval.");
    }
}