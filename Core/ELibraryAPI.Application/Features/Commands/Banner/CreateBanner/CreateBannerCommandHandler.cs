using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;

public sealed class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommandRequest, Result<CreateBannerCommandResponse>>
{
    public Task<Result<CreateBannerCommandResponse>> Handle(CreateBannerCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
