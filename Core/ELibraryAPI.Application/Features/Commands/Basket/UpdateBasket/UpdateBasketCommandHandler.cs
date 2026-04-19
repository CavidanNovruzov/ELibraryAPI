using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.UpdateBasket;

public sealed class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, Result<UpdateBasketCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateBasketCommandResponse>> Handle(UpdateBasketCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Basket, Guid>();

        var basket = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (basket == null)
        {
            return Result<UpdateBasketCommandResponse>.Failure("Basket not found.");
        }

        if (basket.UserId != request.UserId)
        {
            var isAnotherBasketExists = await readRepo.ExistsAsync(
                x => x.UserId == request.UserId && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isAnotherBasketExists)
            {
                return Result<UpdateBasketCommandResponse>.Failure("The target user already has an active basket.");
            }
        }

        _mapper.Map(request, basket);

        writeRepo.Update(basket);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateBasketCommandResponse>.Success(
            new UpdateBasketCommandResponse(basket.Id),
            "Basket updated successfully.");
    }
}