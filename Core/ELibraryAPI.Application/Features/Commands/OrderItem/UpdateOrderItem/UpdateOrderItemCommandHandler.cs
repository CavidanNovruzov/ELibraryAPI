using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

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
        var orderItemReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.OrderItem, Guid>();
        var orderItemWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderItem, Guid>();
        var orderReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var orderItem = await orderItemReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (orderItem == null)
        {
            return Result<UpdateOrderItemCommandResponse>.Failure("Order item not found.");
        }

        var orderExists = await orderReadRepository.ExistsAsync(x => x.Id == request.OrderId, false, ct);
        if (!orderExists)
        {
            return Result<UpdateOrderItemCommandResponse>.Failure("Order not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdateOrderItemCommandResponse>.Failure("Product not found.");
        }

        if (request.Quantity <= 0)
        {
            return Result<UpdateOrderItemCommandResponse>.Failure("Quantity must be greater than zero.");
        }

        _mapper.Map(request, orderItem);

        orderItemWriteRepository.Update(orderItem);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateOrderItemCommandResponse>.Success(
            new UpdateOrderItemCommandResponse(orderItem.Id),
            "Order item updated successfully.");
    }
}