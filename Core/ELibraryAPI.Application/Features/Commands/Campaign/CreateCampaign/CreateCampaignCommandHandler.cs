using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Campaign.CreateCampaign;

public sealed class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommandRequest, Result<CreateCampaignCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCampaignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CreateCampaignCommandResponse>> Handle(CreateCampaignCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Campaign, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Campaign, Guid>();

        var isTitleExists = await readRepo.ExistsAsync(
            x => x.Title.ToLower() == request.Title.Trim().ToLower(),
            tracking: false,
            ct: ct);

        if (isTitleExists)
        {
            return Result<CreateCampaignCommandResponse>.Failure("A campaign with this title already exists.");
        }

        if (request.DiscountPercent < 0 || request.DiscountPercent > 100)
        {
            return Result<CreateCampaignCommandResponse>.Failure("Discount percent must be between 0 and 100.");
        }

        var campaign = _mapper.Map<Domain.Entities.Concrete.Campaign>(request);

        await writeRepo.AddAsync(campaign, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateCampaignCommandResponse>.Success(
            new CreateCampaignCommandResponse(campaign.Id),
            "Campaign created successfully.");
    }
}