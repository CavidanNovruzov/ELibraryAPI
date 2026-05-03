using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ELibraryAPI.Application.Features.Queries.Tag.GetAllTag;

public sealed class GetAllTagQueryHandler : IRequestHandler<GetAllTagQueryRequest, Result<GetAllTagQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllTagQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllTagQueryResponse>> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
    {
        var tags = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Tag, Guid>()
            .GetAll(tracking: false) 
            .Select(t => new TagListDto(
                t.Id,
                t.Name
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllTagQueryResponse>.Success(new GetAllTagQueryResponse(tags));
    }
}

