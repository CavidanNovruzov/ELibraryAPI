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
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Branch, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Branch, Guid>();

        var branch = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (branch == null)
        {
            return Result.Failure("Branch not found.");
        }

        branch.IsDeleted = true;
        writeRepo.Update(branch);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Branch deleted successfully.");
    }
}