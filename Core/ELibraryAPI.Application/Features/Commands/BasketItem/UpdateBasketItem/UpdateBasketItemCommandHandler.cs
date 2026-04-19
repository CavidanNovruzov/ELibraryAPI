using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;

public sealed class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, Result<UpdateBasketItemCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBasketItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateBasketItemCommandResponse>> Handle(UpdateBasketItemCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.BasketItem, Guid>();

        var basketItem = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (basketItem == null)
        {
            return Result<UpdateBasketItemCommandResponse>.Failure("Basket item not found.");
        }

        _mapper.Map(request, basketItem);

        writeRepo.Update(basketItem);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateBasketItemCommandResponse>.Success(
            new UpdateBasketItemCommandResponse(basketItem.Id),
            "Basket item updated successfully.");
    }
}