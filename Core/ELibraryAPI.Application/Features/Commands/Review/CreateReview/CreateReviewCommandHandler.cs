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
        var reviewReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();
        var reviewWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Review, Guid>();
        var productReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var productExists = await productReadRepo.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
            return Result<CreateReviewCommandResponse>.Failure("Product not found.");

        if (request.Rating < 1 || request.Rating > 5)
            return Result<CreateReviewCommandResponse>.Failure("Rating must be between 1 and 5.");

        var alreadyReviewed = await reviewReadRepo.ExistsAsync(
            x => x.ProductId == request.ProductId && x.UserId == request.UserId,
            false,
            ct);

        if (alreadyReviewed)
            return Result<CreateReviewCommandResponse>.Failure("You have already reviewed this product.");

        var review = _mapper.Map<Domain.Entities.Concrete.Review>(request);

        review.IsApproved = false;

        await reviewWriteRepo.AddAsync(review, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateReviewCommandResponse>.Success(
            new CreateReviewCommandResponse(review.Id),
            "Review submitted successfully and is awaiting approval.");
    }
}