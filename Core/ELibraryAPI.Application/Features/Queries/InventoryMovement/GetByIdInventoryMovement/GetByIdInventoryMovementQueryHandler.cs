using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ELibraryAPI.Application.Features.Queries.InventoryMovement.GetByIdInventoryMovement;

public sealed class GetByIdInventoryMovementQueryValidator : AbstractValidator<GetByIdInventoryMovementQueryRequest>
{
    public GetByIdInventoryMovementQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Hərəkət ID-si mütləqdir.")
            .NotEqual(Guid.Empty).WithMessage("Geçərli bir ID daxil edin.");
    }
}

public sealed class GetByIdInventoryMovementQueryHandler : IRequestHandler<GetByIdInventoryMovementQueryRequest, Result<GetByIdInventoryMovementQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetByIdInventoryMovementQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetByIdInventoryMovementQueryResponse>> Handle(GetByIdInventoryMovementQueryRequest request, CancellationToken cancellationToken)
    {

        var movement = await _unitOfWork
            .ReadRepository<Domain.Entities.Concrete.InventoryMovement, Guid>()
            .GetAll(tracking: false)
            .Where(im => im.Id == request.Id)
            .Select(im => new InventoryMovementDetailDto(
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
            .FirstOrDefaultAsync(cancellationToken);

        if (movement == null)
            return Result<GetByIdInventoryMovementQueryResponse>.Failure("Anbar hərəkəti tapılmadı.");

        return Result<GetByIdInventoryMovementQueryResponse>.Success(new GetByIdInventoryMovementQueryResponse(movement));
    }
}