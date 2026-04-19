using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.DeleteTransaction;

public sealed class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTransactionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteTransactionCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Transaction, Guid>();

        var transaction = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (transaction == null)
        {
            return Result.Failure("Transaction record not found.");
        }

        transaction.IsDeleted = true;
        writeRepository.Update(transaction);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Transaction record deleted successfully.");
    }
}
