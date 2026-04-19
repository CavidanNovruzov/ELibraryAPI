using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Order, Guid>();

        // Check for unique OrderNumber
        var isOrderNumberExists = await readRepo.ExistsAsync(
            x => x.OrderNumber == request.OrderNumber.Trim(),
            tracking: false,
            ct: ct);

        if (isOrderNumberExists)
        {
            return Result<CreateOrderCommandResponse>.Failure("An order with this order number already exists.");
        }

        // Basic validation for TotalAmount
        if (request.TotalAmount < 0)
        {
            return Result<CreateOrderCommandResponse>.Failure("Total amount cannot be negative.");
        }

        var order = _mapper.Map<Domain.Entities.Concrete.Order>(request);

        await writeRepo.AddAsync(order, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateOrderCommandResponse>.Success(
            new CreateOrderCommandResponse(order.Id),
            "Order created successfully.");
    }
}