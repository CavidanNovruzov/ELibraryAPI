using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.DeleteStock;

public sealed class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteStockCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteStockCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();

        var stock = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (stock == null)
        {
            return Result.Failure("Stock record not found.");
        }

        stock.IsDeleted = true;
        writeRepository.Update(stock);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Stock record deleted successfully.");
    }
}