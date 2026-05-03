using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Publisher.GetAllPublisher;

public sealed class GetAllPublisherQueryHandler : IRequestHandler<GetAllPublisherQueryRequest, Result<GetAllPublisherQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPublisherQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllPublisherQueryResponse>> Handle(GetAllPublisherQueryRequest request, CancellationToken cancellationToken)
    {
        var publishers = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Publisher, Guid>()
            .GetAll(tracking: false) 
            .Select(p => new PublisherListDto(
                p.Id,
                p.Name,
                p.Products.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllPublisherQueryResponse>.Success(new GetAllPublisherQueryResponse(publishers));
    }
}