using ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;
using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetMovementsByProduct
{
    public sealed class GetMovementsByProductQueryHandler : IRequestHandler<GetMovementsByProductQueryRequest, Result<GetMovementsByProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovementsByProductQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetMovementsByProductQueryResponse>> Handle(GetMovementsByProductQueryRequest request, CancellationToken cancellationToken)
        {
            var movements = await _unitOfWork
                .ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>()
                .GetAll(tracking: false)
                .Where(im => im.ProductId == request.ProductId)
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

            return Result<GetMovementsByProductQueryResponse>.Success(new GetMovementsByProductQueryResponse(movements));
        }
    }
}
