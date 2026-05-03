using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;

public sealed class GetAllInventoryMovementQueryHandler : IRequestHandler<GetAllInventoryMovementQueryRequest, Result<GetAllInventoryMovementQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllInventoryMovementQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllInventoryMovementQueryResponse>> Handle(GetAllInventoryMovementQueryRequest request, CancellationToken cancellationToken)
    {
        var movements = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>()
            .GetAll(tracking: false)
            .OrderByDescending(im => im.CreatedDate) 
            .Select(im => new InventoryMovementListDto(
                im.Id,
                im.ProductId,
                im.Product.Title,      
                im.FromBranchId,
                im.FromBranch.Name,    
                im.ToBranchId,
                im.ToBranch.Name,      
                im.Quantity,
                im.Type,
                im.CreatedDate
            ))
            .ToListAsync(cancellationToken);

        return Result<GetAllInventoryMovementQueryResponse>.Success(new GetAllInventoryMovementQueryResponse(movements));
    }
}