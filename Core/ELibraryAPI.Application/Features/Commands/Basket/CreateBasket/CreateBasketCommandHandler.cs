using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.CreateBasket;

public sealed class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommandRequest, Result<CreateBasketCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBasketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateBasketCommandResponse>> Handle(CreateBasketCommandRequest request, CancellationToken ct)
    {
        var basketReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();
        var basketWriteRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Basket, Guid>();

        var hasActiveBasket = await basketReadRepo.ExistsAsync(x => x.UserId == request.UserId, ct: ct);

        if (hasActiveBasket)
        {
            return Result<CreateBasketCommandResponse>.Failure("User already has an active shopping basket.");
        }

        var basket = _mapper.Map<Domain.Entities.Concrete.Basket>(request);

        await basketWriteRepo.AddAsync(basket, ct);

        var result = await _unitOfWork.SaveAsync(ct);

        if (result > 0)
        {
            return Result<CreateBasketCommandResponse>.Success(new CreateBasketCommandResponse(basket.Id));
        }

        return Result<CreateBasketCommandResponse>.Failure("An error occurred while creating the basket.");
    }
}