using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;

public sealed class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommandRequest, Result<UpdateBannerCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBannerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateBannerCommandResponse>> Handle(UpdateBannerCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Banner, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Banner, Guid>();

        var banner = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (banner == null)
        {
            return Result<UpdateBannerCommandResponse>.Failure("Banner not found.");
        }

        _mapper.Map(request, banner);

        writeRepo.Update(banner);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateBannerCommandResponse>.Success(new UpdateBannerCommandResponse(banner.Id), "Banner updated successfully.");
    }
}