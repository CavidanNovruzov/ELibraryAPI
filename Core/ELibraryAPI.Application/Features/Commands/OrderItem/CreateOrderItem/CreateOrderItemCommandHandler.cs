using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;

public sealed class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommandRequest, Result<CreateOrderItemCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateOrderItemCommandResponse>> Handle(CreateOrderItemCommandRequest request, CancellationToken ct)
    {
        var orderReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var orderItemWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.OrderItem, Guid>();

        var orderExists = await orderReadRepository.ExistsAsync(x => x.Id == request.OrderId, false, ct);
        if (!orderExists)
        {
            return Result<CreateOrderItemCommandResponse>.Failure("Order not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreateOrderItemCommandResponse>.Failure("Product not found.");
        }

        if (request.Quantity <= 0)
        {
            return Result<CreateOrderItemCommandResponse>.Failure("Quantity must be greater than zero.");
        }

        var orderItem = _mapper.Map<Domain.Entities.Concrete.OrderItem>(request);

        await orderItemWriteRepository.AddAsync(orderItem, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateOrderItemCommandResponse>.Success(
            new CreateOrderItemCommandResponse(orderItem.Id),
            "Order item added successfully.");
    }
}