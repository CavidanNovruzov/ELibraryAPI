using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;

public sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommandRequest, Result<CreateTransactionCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateTransactionCommandResponse>> Handle(CreateTransactionCommandRequest request, CancellationToken ct)
    {
        var transactionReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var transactionWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Transaction, Guid>();
        var orderReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();

        // 1. Verify Order exists
        var orderExists = await orderReadRepository.ExistsAsync(x => x.Id == request.OrderId, false, ct);
        if (!orderExists)
        {
            return Result<CreateTransactionCommandResponse>.Failure("Associated order not found.");
        }

        // 2. Prevent duplicate Transaction IDs from the provider
        var transactionExists = await transactionReadRepository.ExistsAsync(
            x => x.TransactionId == request.TransactionId,
            false,
            ct);

        if (transactionExists)
        {
            return Result<CreateTransactionCommandResponse>.Failure("A transaction with this ID already exists.");
        }

        // 3. Basic amount validation
        if (request.Amount <= 0)
        {
            return Result<CreateTransactionCommandResponse>.Failure("Transaction amount must be greater than zero.");
        }

        // 4. Map and persist
        var transaction = _mapper.Map<Domain.Entities.Concrete.Transaction>(request);

        await transactionWriteRepository.AddAsync(transaction, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateTransactionCommandResponse>.Success(
            new CreateTransactionCommandResponse(transaction.Id),
            "Transaction record created successfully.");
    }
}