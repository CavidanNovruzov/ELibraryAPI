using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;

public sealed class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommandRequest, Result<UpdateTransactionCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateTransactionCommandResponse>> Handle(UpdateTransactionCommandRequest request, CancellationToken ct)
    {
        var transactionReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var orderReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();

        var transaction = await transactionReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (transaction == null)
            return Result<UpdateTransactionCommandResponse>.Failure("Transaction record not found.");

        var orderExists = await orderReadRepo.ExistsAsync(x => x.Id == request.OrderId, false, ct);
        if (!orderExists)
            return Result<UpdateTransactionCommandResponse>.Failure("Associated order not found.");

        if (transaction.TransactionId != request.TransactionId)
        {
            var isTransactionIdExists = await transactionReadRepo.ExistsAsync(
                x => x.TransactionId == request.TransactionId && x.Id != request.Id,
                false, ct);

            if (isTransactionIdExists)
                return Result<UpdateTransactionCommandResponse>.Failure("Another transaction with this Provider ID already exists.");
        }

        if (request.Amount <= 0)
            return Result<UpdateTransactionCommandResponse>.Failure("Transaction amount must be greater than zero.");

        _mapper.Map(request, transaction);

        // Tracking aktiv olduğu üçün writeRepo.Update ehtiyac yoxdur.
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateTransactionCommandResponse>.Success(
            new UpdateTransactionCommandResponse(transaction.Id),
            "Transaction record updated successfully.");
    }
}