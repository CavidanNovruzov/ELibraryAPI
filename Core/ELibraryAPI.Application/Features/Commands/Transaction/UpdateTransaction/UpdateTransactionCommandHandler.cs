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
        var transactionReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var transactionWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var orderReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();

        var transaction = await transactionReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (transaction == null)
        {
            return Result<UpdateTransactionCommandResponse>.Failure("Transaction record not found.");
        }

        // 1. Verify Order exists
        var orderExists = await orderReadRepository.ExistsAsync(x => x.Id == request.OrderId, false, ct);
        if (!orderExists)
        {
            return Result<UpdateTransactionCommandResponse>.Failure("Associated order not found.");
        }

        // 2. Check for duplicate TransactionId if it is being changed
        if (transaction.TransactionId != request.TransactionId)
        {
            var isTransactionIdExists = await transactionReadRepository.ExistsAsync(
                x => x.TransactionId == request.TransactionId && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isTransactionIdExists)
            {
                return Result<UpdateTransactionCommandResponse>.Failure("Another transaction with this Provider ID already exists.");
            }
        }

        // 3. Basic amount validation
        if (request.Amount <= 0)
        {
            return Result<UpdateTransactionCommandResponse>.Failure("Transaction amount must be greater than zero.");
        }

        // 4. Map changes and persist
        _mapper.Map(request, transaction);

        transactionWriteRepository.Update(transaction);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateTransactionCommandResponse>.Success(
            new UpdateTransactionCommandResponse(transaction.Id),
            "Transaction record updated successfully.");
    }
}