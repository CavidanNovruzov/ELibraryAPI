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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Basket, Guid>();

        var isBasketExists = await readRepo.ExistsAsync(
            x => x.UserId == request.UserId,
            tracking: false,
            ct: ct);

        if (isBasketExists)
        {
            return Result<CreateBasketCommandResponse>.Failure("User already has an active basket.");
        }

        var basket = _mapper.Map<Domain.Entities.Concrete.Basket>(request);

        await writeRepo.AddAsync(basket, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateBasketCommandResponse>.Success(
            new CreateBasketCommandResponse(basket.Id),
            "Basket created successfully.");
    }
}