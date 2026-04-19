using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PromoCode.UpdatePromoCode;

public sealed class UpdatePromoCodeCommandHandler : IRequestHandler<UpdatePromoCodeCommandRequest, Result<UpdatePromoCodeCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePromoCodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdatePromoCodeCommandResponse>> Handle(UpdatePromoCodeCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.PromoCode, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.PromoCode, Guid>();

        var promoCode = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (promoCode == null)
        {
            return Result<UpdatePromoCodeCommandResponse>.Failure("Promo code not found.");
        }

        // Validate unique code if the name is being changed
        var normalizedCode = request.Code.Trim().ToUpper();
        if (promoCode.Code != normalizedCode)
        {
            var isCodeExists = await readRepository.ExistsAsync(
                x => x.Code == normalizedCode && x.Id != request.Id,
                tracking: false,
                ct: ct);

            if (isCodeExists)
            {
                return Result<UpdatePromoCodeCommandResponse>.Failure("Another promo code with this name already exists.");
            }
        }

        // Logic validation
        if (request.StartDate >= request.EndDate)
        {
            return Result<UpdatePromoCodeCommandResponse>.Failure("Start date must be earlier than the end date.");
        }

        if (request.DiscountPercent <= 0 || request.DiscountPercent > 100)
        {
            return Result<UpdatePromoCodeCommandResponse>.Failure("Discount percentage must be between 1 and 100.");
        }

        if (request.UsageLimit <= 0)
        {
            return Result<UpdatePromoCodeCommandResponse>.Failure("Usage limit must be at least 1.");
        }

        _mapper.Map(request, promoCode);
        promoCode.Code = normalizedCode;

        writeRepository.Update(promoCode);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdatePromoCodeCommandResponse>.Success(
            new UpdatePromoCodeCommandResponse(promoCode.Id),
            "Promo code updated successfully.");
    }
}