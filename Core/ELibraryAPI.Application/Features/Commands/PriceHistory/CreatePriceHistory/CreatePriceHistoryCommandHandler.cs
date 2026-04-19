using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.CreatePriceHistory;

public sealed class CreatePriceHistoryCommandHandler : IRequestHandler<CreatePriceHistoryCommandRequest, Result<CreatePriceHistoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePriceHistoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreatePriceHistoryCommandResponse>> Handle(CreatePriceHistoryCommandRequest request, CancellationToken ct)
    {
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var priceHistoryWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.PriceHistory, Guid>();

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<CreatePriceHistoryCommandResponse>.Failure("Product not found.");
        }

        if (request.NewPrice < 0)
        {
            return Result<CreatePriceHistoryCommandResponse>.Failure("Price cannot be negative.");
        }

        var priceHistory = _mapper.Map<Domain.Entities.Concrete.PriceHistory>(request);

        await priceHistoryWriteRepository.AddAsync(priceHistory, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreatePriceHistoryCommandResponse>.Success(
            new CreatePriceHistoryCommandResponse(priceHistory.Id),
            "Price history record created successfully.");
    }
}