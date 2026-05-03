using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;

public sealed class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQueryRequest, Result<GetAllBannerQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBannerQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllBannerQueryResponse>> Handle(GetAllBannerQueryRequest request, CancellationToken cancellationToken)
    {
        var banners = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Banner, Guid>()
            .GetAll(tracking: false, cancellationToken)
            .Where(b => b.IsActive)
            .OrderBy(b => b.Order)
            .Select(b => new BannerListDto(
                b.Id,
                b.ImageUrl,
                b.RedirectUrl,
                b.Title
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllBannerQueryResponse>.Success(new GetAllBannerQueryResponse(banners));
    }
}