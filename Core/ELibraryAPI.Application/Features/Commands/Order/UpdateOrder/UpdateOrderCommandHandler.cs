using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Order.UpdateOrder;

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, Result<UpdateOrderCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateOrderCommandResponse>> Handle(UpdateOrderCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Order, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Order, Guid>();

        var order = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (order == null)
        {
            return Result<UpdateOrderCommandResponse>.Failure("Order not found.");
        }

        if (order.OrderNumber != request.OrderNumber.Trim())
        {
            var isOrderNumberExists = await readRepo.ExistsAsync(
                x => x.OrderNumber == request.OrderNumber.Trim() && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isOrderNumberExists)
            {
                return Result<UpdateOrderCommandResponse>.Failure("Another order with this order number already exists.");
            }
        }

        if (request.TotalAmount < 0)
        {
            return Result<UpdateOrderCommandResponse>.Failure("Total amount cannot be negative.");
        }

        _mapper.Map(request, order);

        writeRepo.Update(order);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateOrderCommandResponse>.Success(
            new UpdateOrderCommandResponse(order.Id),
            "Order updated successfully.");
    }
}