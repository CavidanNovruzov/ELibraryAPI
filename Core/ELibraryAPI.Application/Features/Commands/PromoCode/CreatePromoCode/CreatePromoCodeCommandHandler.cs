using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PromoCode.CreatePromoCode;

public sealed class CreatePromoCodeCommandHandler : IRequestHandler<CreatePromoCodeCommandRequest, Result<CreatePromoCodeCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreatePromoCodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreatePromoCodeCommandResponse>> Handle(CreatePromoCodeCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.PromoCode, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.PromoCode, Guid>();

        var isCodeExists = await readRepository.ExistsAsync(
            x => x.Code == request.Code.Trim().ToUpper(),
            tracking: false,
            ct: ct);

        if (isCodeExists)
        {
            return Result<CreatePromoCodeCommandResponse>.Failure("A promo code with this name already exists.");
        }

        if (request.StartDate >= request.EndDate)
        {
            return Result<CreatePromoCodeCommandResponse>.Failure("Start date must be earlier than the end date.");
        }

        if (request.DiscountPercent <= 0 || request.DiscountPercent > 100)
        {
            return Result<CreatePromoCodeCommandResponse>.Failure("Discount percentage must be between 1 and 100.");
        }

        if (request.UsageLimit <= 0)
        {
            return Result<CreatePromoCodeCommandResponse>.Failure("Usage limit must be at least 1.");
        }

        var promoCode = _mapper.Map<Domain.Entities.Concrete.PromoCode>(request);
        promoCode.Code = request.Code.Trim().ToUpper();

        await writeRepository.AddAsync(promoCode, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreatePromoCodeCommandResponse>.Success(
            new CreatePromoCodeCommandResponse(promoCode.Id),
            "Promo code created successfully.");
    }
}