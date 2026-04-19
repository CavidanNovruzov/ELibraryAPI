using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;

public sealed class CreateInventoryMovementCommandHandler : IRequestHandler<CreateInventoryMovementCommandRequest, Result<CreateInventoryMovementCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateInventoryMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateInventoryMovementCommandResponse>> Handle(CreateInventoryMovementCommandRequest request, CancellationToken ct)
    {
        var productRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var stockRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var stockWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();
        var movementWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var productExists = await productRepo.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateInventoryMovementCommandResponse>.Failure("Product not found.");
        }

        var fromStock = await stockRepo.GetSingleAsync(
            x => x.BranchId == request.FromBranchId && x.ProductId == request.ProductId,
            tracking: true,
            ct: ct);

        if (fromStock == null || fromStock.Quantity < request.Quantity)
        {
            return Result<CreateInventoryMovementCommandResponse>.Failure("Insufficient stock in the source branch.");
        }

        var toStock = await stockRepo.GetSingleAsync(
            x => x.BranchId == request.ToBranchId && x.ProductId == request.ProductId,
            tracking: true,
            ct: ct);

        if (toStock == null)
        {
            toStock = new Domain.Entities.Concrete.Stock
            {
                BranchId = request.ToBranchId,
                ProductId = request.ProductId,
                Quantity = 0
            };
            await stockWriteRepo.AddAsync(toStock, ct);
        }

        fromStock.Quantity -= request.Quantity;
        toStock.Quantity += request.Quantity;

        stockWriteRepo.Update(fromStock);
        stockWriteRepo.Update(toStock);

        var movement = _mapper.Map<Domain.Entities.Concrete.InventoryMovement>(request);
        await movementWriteRepo.AddAsync(movement, ct);

        await _unitOfWork.SaveAsync(ct);

        return Result<CreateInventoryMovementCommandResponse>.Success(
            new CreateInventoryMovementCommandResponse(movement.Id),
            "Inventory movement completed successfully.");
    }
}