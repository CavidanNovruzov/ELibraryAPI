
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Campaign.GetAllCampaign;

public sealed class GetAllCampaignQueryHandler : IRequestHandler<GetAllCampaignQueryRequest, Result<GetAllCampaignQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCampaignQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllCampaignQueryResponse>> Handle(GetAllCampaignQueryRequest request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow; 

        var campaigns = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Campaign, Guid>()
            .GetAll(tracking: false)
            .Where(c => !c.IsDeleted)
            .Select(c => new CampaignListDto(
                c.Id,
                c.Title,
                c.Description,
                c.DiscountPercent,
                c.StartDate,
                c.EndDate,
                c.IsActive && c.StartDate <= now && c.EndDate >= now
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllCampaignQueryResponse>.Success(new GetAllCampaignQueryResponse(campaigns));
    }
}