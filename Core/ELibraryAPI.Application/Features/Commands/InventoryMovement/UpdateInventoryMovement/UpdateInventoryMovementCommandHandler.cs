using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;

public sealed class UpdateInventoryMovementCommandHandler : IRequestHandler<UpdateInventoryMovementCommandRequest, Result<UpdateInventoryMovementCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateInventoryMovementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateInventoryMovementCommandResponse>> Handle(UpdateInventoryMovementCommandRequest request, CancellationToken ct)
    {
        var movementRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();
        var stockRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var stockWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();
        var movementWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var movement = await movementRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (movement == null)
        {
            return Result<UpdateInventoryMovementCommandResponse>.Failure("Inventory movement not found.");
        }

        var oldFromStock = await stockRepo.GetSingleAsync(x => x.BranchId == movement.FromBranchId && x.ProductId == movement.ProductId, true, ct);
        var oldToStock = await stockRepo.GetSingleAsync(x => x.BranchId == movement.ToBranchId && x.ProductId == movement.ProductId, true, ct);

        if (oldFromStock != null) oldFromStock.Quantity += movement.Quantity;
        if (oldToStock != null) oldToStock.Quantity -= movement.Quantity;

        var newFromStock = await stockRepo.GetSingleAsync(x => x.BranchId == request.FromBranchId && x.ProductId == request.ProductId, true, ct);
        if (newFromStock == null || newFromStock.Quantity < request.Quantity)
        {
            return Result<UpdateInventoryMovementCommandResponse>.Failure("Insufficient stock in the new source branch.");
        }

        var newToStock = await stockRepo.GetSingleAsync(x => x.BranchId == request.ToBranchId && x.ProductId == request.ProductId, true, ct);
        if (newToStock == null)
        {
            newToStock = new Domain.Entities.Concrete.Stock { BranchId = request.ToBranchId, ProductId = request.ProductId, Quantity = 0 };
            await stockWriteRepo.AddAsync(newToStock, ct);
        }

        newFromStock.Quantity -= request.Quantity;
        newToStock.Quantity += request.Quantity;

        _mapper.Map(request, movement);

        movementWriteRepo.Update(movement);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateInventoryMovementCommandResponse>.Success(new UpdateInventoryMovementCommandResponse(movement.Id), "Inventory movement updated successfully.");
    }
}