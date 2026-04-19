using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.CreateReview;

public sealed class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, Result<CreateReviewCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateReviewCommandResponse>> Handle(CreateReviewCommandRequest request, CancellationToken ct)
    {
        var reviewReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();
        var reviewWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Review, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        // 1. Verify product exists
        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateReviewCommandResponse>.Failure("Product not found.");
        }

        // 2. Validate Rating range (assuming 1-5 scale)
        if (request.Rating < 1 || request.Rating > 5)
        {
            return Result<CreateReviewCommandResponse>.Failure("Rating must be between 1 and 5.");
        }

        // 3. Prevent duplicate reviews from the same user for the same product
        var alreadyReviewed = await reviewReadRepository.ExistsAsync(
            x => x.ProductId == request.ProductId && x.UserId == request.UserId,
            false,
            ct);

        if (alreadyReviewed)
        {
            return Result<CreateReviewCommandResponse>.Failure("You have already reviewed this product.");
        }

        // 4. Map and persist
        var review = _mapper.Map<Domain.Entities.Concrete.Review>(request);

        await reviewWriteRepository.AddAsync(review, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateReviewCommandResponse>.Success(
            new CreateReviewCommandResponse(review.Id),
            "Review submitted successfully.");
    }
}