using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Tag.UpdateTag;

public sealed class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommandRequest, Result<UpdateTagCommandResponse>>
{
    public Task<Result<UpdateTagCommandResponse>> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
