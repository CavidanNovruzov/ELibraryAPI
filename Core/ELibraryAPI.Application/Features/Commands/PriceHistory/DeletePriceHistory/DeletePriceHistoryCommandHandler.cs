using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.DeletePriceHistory;

public sealed class DeletePriceHistoryCommandHandler : IRequestHandler<DeletePriceHistoryCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePriceHistoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePriceHistoryCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.PriceHistory, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.PriceHistory, Guid>();

        var priceHistory = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (priceHistory == null)
        {
            return Result.Failure("Price history record not found.");
        }

        priceHistory.IsDeleted = true;
        writeRepository.Update(priceHistory);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Price history record deleted successfully.");
    }
}