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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Review, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Review, Guid>();

        var review = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (review == null)
            return Result.Failure("Review not found.");

        writeRepo.Remove(review);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Review deleted successfully.");
    }
}