using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.CoverType.UpdateCoverType;

public sealed class UpdateCoverTypeCommandHandler : IRequestHandler<UpdateCoverTypeCommandRequest, Result<UpdateCoverTypeCommandResponse>>
{
    public Task<Result<UpdateCoverTypeCommandResponse>> Handle(UpdateCoverTypeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
