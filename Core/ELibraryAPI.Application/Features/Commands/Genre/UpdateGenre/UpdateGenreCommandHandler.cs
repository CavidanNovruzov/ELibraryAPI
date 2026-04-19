using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.UpdateGenre;

public sealed class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, Result<UpdateGenreCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UpdateGenreCommandResponse>> Handle(UpdateGenreCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Genre, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Genre, Guid>();

        var genre = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (genre == null || genre.IsDeleted)
            return Result<UpdateGenreCommandResponse>.Failure("Genre not found.");

        if (genre.Name.ToLower() != request.Name.ToLower())
        {
            var isNameUsed = await readRepo.ExistsAsync(
                predicate: x => x.Name.ToLower() == request.Name.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

            if (isNameUsed)
                return Result<UpdateGenreCommandResponse>.Failure("A genre with this name already exists.");
        }

        _mapper.Map(request, genre);

        writeRepo.Update(genre);
        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateGenreCommandResponse>.Success(new UpdateGenreCommandResponse(genre.Id));
    }
}
