using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.UpdateBranch;

public sealed class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommandRequest, Result<UpdateBranchCommandResponse>>
{
    public Task<Result<UpdateBranchCommandResponse>> Handle(UpdateBranchCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
