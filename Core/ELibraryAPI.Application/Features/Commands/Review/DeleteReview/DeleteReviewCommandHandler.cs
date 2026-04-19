using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Review.DeleteReview;

public sealed class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteReviewCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Review, Guid>();

        var review = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (review == null)
        {
            return Result.Failure("Review not found.");
        }

        review.IsDeleted = true;
        writeRepository.Update(review);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Review deleted successfully.");
    }
}