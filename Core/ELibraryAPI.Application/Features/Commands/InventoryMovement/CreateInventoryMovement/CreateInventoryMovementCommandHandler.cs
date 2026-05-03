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
        var productReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var stockReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Stock, Guid>();
        var stockWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Stock, Guid>();
        var movementWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.InventoryMovement, Guid>();

        var productExists = await productReadRepo.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
            return Result<CreateInventoryMovementCommandResponse>.Failure("Product not found.");

        var fromStock = await stockReadRepo.GetSingleAsync(
            x => x.BranchId == request.FromBranchId && x.ProductId == request.ProductId,
            tracking: true, ct: ct);

        if (fromStock == null || fromStock.Quantity < request.Quantity)
            return Result<CreateInventoryMovementCommandResponse>.Failure("Insufficient stock in the source branch.");

        var toStock = await stockReadRepo.GetSingleAsync(
            x => x.BranchId == request.ToBranchId && x.ProductId == request.ProductId,
            tracking: true, ct: ct);

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

        var movement = _mapper.Map<Domain.Entities.Concrete.InventoryMovement>(request);
        movement.Status = "Completed"; // Susmaya görə tamamlanmış sayılır


        await movementWriteRepo.AddAsync(movement, ct);

        var saveResult = await _unitOfWork.SaveAsync(ct);

        if (saveResult > 0)
        {
            return Result<CreateInventoryMovementCommandResponse>.Success(
                new CreateInventoryMovementCommandResponse(movement.Id),
                "Inventory transfer completed successfully.");
        }

        return Result<CreateInventoryMovementCommandResponse>.Failure("An error occurred during inventory movement.");
    }
}