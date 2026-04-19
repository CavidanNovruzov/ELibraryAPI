using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.DeleteCampaign;

public sealed class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCampaignCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCampaignCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Campaign, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Campaign, Guid>();

        var campaign = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (campaign == null)
        {
            return Result.Failure("Campaign not found.");
        }

        campaign.IsDeleted = true;
        writeRepo.Update(campaign);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Campaign deleted successfully.");
    }
}