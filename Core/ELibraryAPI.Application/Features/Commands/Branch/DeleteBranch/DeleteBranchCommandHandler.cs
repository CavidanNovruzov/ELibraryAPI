using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Branch.DeleteBranch;

public sealed class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBranchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBranchCommandRequest request, CancellationToken ct)
    {
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Branch, Guid>();

        var isRemoved = await writeRepo.RemoveAsync(request.Id, ct);

        if (!isRemoved)
            return Result.Failure("Branch not found or already deleted.");

        var result = await _unitOfWork.SaveAsync(ct);

        return result > 0
            ? Result.Success()
            : Result.Failure("An error occurred while deleting the branch.");
    }
}