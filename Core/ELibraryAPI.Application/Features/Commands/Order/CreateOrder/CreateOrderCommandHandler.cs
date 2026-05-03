using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Commands.Order.CreateOrder;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, Result<CreateOrderCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateOrderCommandResponse>> Handle(CreateOrderCommandRequest request, CancellationToken ct)
    {
        var basketReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();
        var orderWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Order, Guid>();
        var basketWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Basket, Guid>();


        var basket = await basketReadRepo.GetAll(tracking: true, ct: ct)
            .Include(b => b.BasketItems)
            .ThenInclude(bi => bi.Product)
            .FirstOrDefaultAsync(b => b.UserId == request.UserId && !b.IsDeleted, ct);

        if (basket == null || !basket.BasketItems.Any())
        {
            return Result<CreateOrderCommandResponse>.Failure("Your basket is empty.");
        }

        decimal calculatedTotal = 0;
        foreach (var item in basket.BasketItems)
        {
            if (item.Product.TotalStockCount < item.Quantity)
            {
                return Result<CreateOrderCommandResponse>.Failure($"Product '{item.Product.Title}' is out of stock.");
            }
            calculatedTotal += item.Product.SalePrice * item.Quantity;
        }

        var order = new Domain.Entities.Concrete.Order
        {
            UserId = request.UserId,
            OrderNote = request.OrderNote,
            OrderNumber = $"ORD-{DateTime.Now:yyyyMMddHHmmss}",
            OrderStatusId = request.OrderStatusId,
            PaymentMethodId = request.PaymentMethodId,
            ShippingMethodId = request.ShippingMethodId,
            TotalAmount = calculatedTotal
        };

        foreach (var item in basket.BasketItems)
        {
            order.OrderItems.Add(new Domain.Entities.Concrete.OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.Product.SalePrice
            });

            item.Product.TotalStockCount -= item.Quantity;
        }

        await orderWriteRepo.AddAsync(order, ct);

        basketWriteRepo.Remove(basket);

        var result = await _unitOfWork.SaveAsync(ct);

        if (result > 0)
        {
            return Result<CreateOrderCommandResponse>.Success(
                new CreateOrderCommandResponse(order.Id),
                "Order has been placed successfully.");
        }

        return Result<CreateOrderCommandResponse>.Failure("An error occurred while processing your order.");
    }
}