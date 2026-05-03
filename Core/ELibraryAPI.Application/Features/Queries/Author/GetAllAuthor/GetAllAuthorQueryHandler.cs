using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;

public sealed class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, Result<GetAllAuthorQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllAuthorQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllAuthorQueryResponse>> Handle(GetAllAuthorQueryRequest request, CancellationToken ct)
    {
        var query = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Author, Guid>().GetAll(false);

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var search = request.SearchTerm.Trim().ToLower();
            query = query.Where(a => a.FullName.ToLower().Contains(search));
        }

        var totalCount = await query.CountAsync(ct);

        var authors = await query
            .Include(a => a.ProductAuthors)
            .OrderBy(a => a.FullName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(a => new AuthorListDto(
                a.Id,
                a.FullName,
                a.Country,
                a.ProductAuthors.Count
            ))
            .ToListAsync(ct);

        return Result<GetAllAuthorQueryResponse>.Success(new GetAllAuthorQueryResponse(authors, totalCount));
    }
}