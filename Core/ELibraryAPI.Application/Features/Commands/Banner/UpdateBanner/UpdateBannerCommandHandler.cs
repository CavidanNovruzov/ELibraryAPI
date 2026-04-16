using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;

public sealed class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommandRequest, Result<UpdateBannerCommandResponse>>
{
    public Task<Result<UpdateBannerCommandResponse>> Handle(UpdateBannerCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
