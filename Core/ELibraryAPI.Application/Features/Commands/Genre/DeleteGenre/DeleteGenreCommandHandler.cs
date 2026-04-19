using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.DeleteGenre;

public sealed class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteGenreCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Genre, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Genre, Guid>();

        var genre = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (genre == null || genre.IsDeleted)
            return Result.Failure("Genre not found.");

        genre.IsDeleted = true;

        writeRepo.Update(genre);
        await _unitOfWork.SaveAsync(ct);

        return Result.Success();
    }
}