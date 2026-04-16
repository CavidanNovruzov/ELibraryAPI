using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Banner.DeleteBanner;

public sealed class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommandRequest, Result>
{
    public Task<Result> Handle(DeleteBannerCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
