using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.CoverType.CreateCoverType;

public sealed class CreateCoverTypeCommandHandler : IRequestHandler<CreateCoverTypeCommandRequest, Result<CreateCoverTypeCommandResponse>>
{
    public Task<Result<CreateCoverTypeCommandResponse>> Handle(CreateCoverTypeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
