using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.Branch.GetAllBranch;

public sealed class GetAllBranchQueryHandler : IRequestHandler<GetAllBranchQueryRequest, Result<GetAllBranchQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllBranchQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllBranchQueryResponse>> Handle(GetAllBranchQueryRequest request, CancellationToken cancellationToken)
    {
        var branches = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.Branch, Guid>()
            .GetAll(tracking: false, cancellationToken)
            .Where(b => !b.IsDeleted)
            .Select(b => new BranchListDto(
                b.Id,
                b.Name,
                b.Location,
                b.Phone,
                b.WorkHours.Count
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllBranchQueryResponse>.Success(new GetAllBranchQueryResponse(branches));
    }
}
