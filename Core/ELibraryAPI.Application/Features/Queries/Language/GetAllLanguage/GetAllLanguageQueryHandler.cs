using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Language.GetAllLanguage;

public sealed class GetAllLanguageQueryHandler : IRequestHandler<GetAllLanguageQueryRequest, Result<GetAllLanguageQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllLanguageQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllLanguageQueryResponse>> Handle(GetAllLanguageQueryRequest request, CancellationToken cancellationToken)
    {
        var languages = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Language, Guid>()
            .GetAll(tracking: false)
            .Select(l => new LanguageListDto(
                l.Id,
                l.Name,
                l.Code,
                l.Products.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllLanguageQueryResponse>.Success(new GetAllLanguageQueryResponse(languages));
    }
}