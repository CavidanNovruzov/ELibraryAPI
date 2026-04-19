using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Publisher.DeletePublisher;

public sealed class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePublisherCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePublisherCommandRequest request, CancellationToken cancellationToken)
    {
        // 1. UnitOfWork Factory vasitəsilə lazımi repository-ləri əldə edirik
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Publisher, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Publisher, Guid>();
        var publisher = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: cancellationToken);

        if (publisher is null || publisher.IsDeleted)
        {
            return Result.Failure("Publisher not found or has already been deleted.");
        }

        publisher.IsDeleted = true;

        writeRepo.Update(publisher);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success("Publisher has been successfully deleted.");
    }
}