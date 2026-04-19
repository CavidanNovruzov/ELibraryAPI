using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.BasketItem.CreateBasketItem;

public sealed class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemCommandRequest, Result<CreateBasketItemCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBasketItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBasketItemCommandResponse>> Handle(CreateBasketItemCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.BasketItem, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.BasketItem, Guid>();

        var existingItem = await readRepo.GetSingleAsync(
            x => x.BasketId == request.BasketId && x.ProductId == request.ProductId,
            tracking: true,
            ct: ct);

        if (existingItem != null)
        {
            existingItem.Quantity += request.Quantity;
            writeRepo.Update(existingItem);
            await _unitOfWork.SaveAsync(ct);

            return Result<CreateBasketItemCommandResponse>.Success(
                new CreateBasketItemCommandResponse(existingItem.Id),
                "Product quantity updated.");
        }

        var basketItem = _mapper.Map<Domain.Entities.Concrete.BasketItem>(request);

        await writeRepo.AddAsync(basketItem, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateBasketItemCommandResponse>.Success(
            new CreateBasketItemCommandResponse(basketItem.Id),
            "Product added to basket.");
    }
}