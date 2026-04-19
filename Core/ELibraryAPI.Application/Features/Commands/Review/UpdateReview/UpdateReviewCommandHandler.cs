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
        var reviewReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();
        var reviewWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Review, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var review = await reviewReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (review == null)
        {
            return Result<UpdateReviewCommandResponse>.Failure("Review not found.");
        }

        // Verify that the user updating the review is the original owner
        if (review.UserId != request.UserId)
        {
            return Result<UpdateReviewCommandResponse>.Failure("You are not authorized to update this review.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateReviewCommandResponse>.Failure("Product not found.");
        }

        if (request.Rating < 1 || request.Rating > 5)
        {
            return Result<UpdateReviewCommandResponse>.Failure("Rating must be between 1 and 5.");
        }

        _mapper.Map(request, review);

        reviewWriteRepository.Update(review);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateReviewCommandResponse>.Success(
            new UpdateReviewCommandResponse(review.Id),
            "Review updated successfully.");
    }
}