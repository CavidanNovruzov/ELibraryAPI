using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;

public sealed class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommandRequest, Result<UpdateOrderItemCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateOrderItemCommandResponse>> Handle(UpdateOrderItemCommandRequest request, CancellationToken ct)
    {
        var orderItemReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderItem, Guid>();
        var orderItemWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderItem, Guid>();

        var orderItem = await orderItemReadRepo.GetAll(tracking: true, ct: ct)
            .Include(oi => oi.Product)
            .FirstOrDefaultAsync(oi => oi.Id == request.Id, ct);

        if (orderItem == null)
            return Result<UpdateOrderItemCommandResponse>.Failure("Order item not found.");

        if (request.Quantity <= 0)
            return Result<UpdateOrderItemCommandResponse>.Failure("Quantity must be greater than zero.");

        int quantityDifference = request.Quantity - orderItem.Quantity;

        if (orderItem.Product != null)
        {
            if (quantityDifference > 0 && orderItem.Product.TotalStockCount < quantityDifference)
            {
                return Result<UpdateOrderItemCommandResponse>.Failure($"Insufficient stock. Available: {orderItem.Product.TotalStockCount}");
            }

            orderItem.Product.TotalStockCount -= quantityDifference;
        }

        _mapper.Map(request, orderItem);
        orderItemWriteRepo.Update(orderItem);

        var result = await _unitOfWork.SaveAsync(ct);

        return result > 0
            ? Result<UpdateOrderItemCommandResponse>.Success(new UpdateOrderItemCommandResponse(orderItem.Id), "Item and stock updated.")
            : Result<UpdateOrderItemCommandResponse>.Failure("No changes applied.");
    }
}