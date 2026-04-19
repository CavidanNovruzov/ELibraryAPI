using AutoMapper;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Genre.CreateGenre;

public sealed class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest, Result<CreateGenreCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGenreCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Result<CreateGenreCommandResponse>> Handle(CreateGenreCommandRequest request, CancellationToken ct)
    {

        var exists = await _unitOfWork.ReadRepository<Domain.Entities.Concrete.Genre, Guid>()
            .ExistsAsync(
                predicate: x => x.Name.ToLower() == request.Name.ToLower() && !x.IsDeleted,
                tracking: false,
                ct: ct);

        if (exists)
            return Result<CreateGenreCommandResponse>.Failure("Genre already exists.");

        var genre = _mapper.Map<Domain.Entities.Concrete.Genre>(request);

        await _unitOfWork.WriteRepository<Domain.Entities.Concrete.Genre, Guid>().AddAsync(genre, ct);
        await _unitOfWork.SaveAsync(ct);

        return Result<CreateGenreCommandResponse>.Success(new CreateGenreCommandResponse(genre.Id));
    }
}
