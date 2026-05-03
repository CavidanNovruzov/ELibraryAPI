using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.CoverType.GetAllCoverType;

public sealed class GetAllCoverTypeQueryHandler : IRequestHandler<GetAllCoverTypeQueryRequest, Result<GetAllCoverTypeQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCoverTypeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllCoverTypeQueryResponse>> Handle(GetAllCoverTypeQueryRequest request, CancellationToken cancellationToken)
    {
       var coverTypes = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.CoverType, Guid>()
            .GetAll(tracking: false) 
            .Select(ct => new CoverTypeListDto(
                ct.Id,
                ct.Name,
                ct.Products.Count 
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllCoverTypeQueryResponse>.Success(new GetAllCoverTypeQueryResponse(coverTypes));
    }
}