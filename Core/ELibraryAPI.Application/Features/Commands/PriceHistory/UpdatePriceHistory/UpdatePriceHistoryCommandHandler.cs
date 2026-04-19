using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.UpdatePriceHistory;

public sealed class UpdatePriceHistoryCommandHandler : IRequestHandler<UpdatePriceHistoryCommandRequest, Result<UpdatePriceHistoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePriceHistoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdatePriceHistoryCommandResponse>> Handle(UpdatePriceHistoryCommandRequest request, CancellationToken ct)
    {
        var priceHistoryReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.PriceHistory, Guid>();
        var priceHistoryWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.PriceHistory, Guid>();
        var productReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();

        var priceHistory = await priceHistoryReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (priceHistory == null)
        {
            return Result<UpdatePriceHistoryCommandResponse>.Failure("Price history record not found.");
        }

        var productExists = await productReadRepository.ExistsAsync(x => x.Id == request.ProductId, false, ct);
        if (!productExists)
        {
            return Result<UpdatePriceHistoryCommandResponse>.Failure("Product not found.");
        }

        if (request.NewPrice < 0 || request.OldPrice < 0)
        {
            return Result<UpdatePriceHistoryCommandResponse>.Failure("Prices cannot be negative.");
        }

        _mapper.Map(request, priceHistory);

        priceHistoryWriteRepository.Update(priceHistory);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdatePriceHistoryCommandResponse>.Success(
            new UpdatePriceHistoryCommandResponse(priceHistory.Id),
            "Price history record updated successfully.");
    }
}