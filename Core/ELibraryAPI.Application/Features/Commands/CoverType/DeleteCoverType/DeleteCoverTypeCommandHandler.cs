using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.CoverType.DeleteCoverType;

public sealed class DeleteCoverTypeCommandHandler : IRequestHandler<DeleteCoverTypeCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCoverTypeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCoverTypeCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.CoverType, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.CoverType, Guid>();

        var coverType = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (coverType == null)
        {
            return Result.Failure("Cover type not found.");
        }

        coverType.IsDeleted = true;
        writeRepo.Update(coverType);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Cover type deleted successfully.");
    }
}