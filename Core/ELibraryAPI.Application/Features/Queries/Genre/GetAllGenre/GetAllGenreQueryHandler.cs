
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Genre.GetAllGenre;

public sealed class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQueryRequest, Result<GetAllGenreQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllGenreQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllGenreQueryResponse>> Handle(GetAllGenreQueryRequest request, CancellationToken cancellationToken)
    {

        var genres = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Genre, Guid>()
            .GetAll(tracking: false) 
            .Select(g => new GenreListDto(
                g.Id,
                g.Name,
                g.ProductGenres.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllGenreQueryResponse>.Success(new GetAllGenreQueryResponse(genres));
    }
}
