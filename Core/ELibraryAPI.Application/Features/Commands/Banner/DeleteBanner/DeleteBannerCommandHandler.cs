
using ELibraryAPI.Application.Features.Commands.Banner.DeleteBanner;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banne.DeleteBanner;

public sealed class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBannerCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteBannerCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Banner, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Banner, Guid>();

        var banner = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (banner == null)
        {
            return Result.Failure("Banner not found.");
        }

        banner.IsDeleted = true;
        writeRepo.Update(banner);
        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Banner removed.");
    }
}