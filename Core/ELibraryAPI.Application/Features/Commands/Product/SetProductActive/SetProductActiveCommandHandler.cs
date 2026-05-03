using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.SetProductActive;

public sealed class SetProductActiveCommandHandler : IRequestHandler<SetProductActiveCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public SetProductActiveCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(SetProductActiveCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Product, Guid>();

        var product = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (product == null)
            return Result.Failure("Product not found.");

        product.IsActive = request.IsActive;
        writeRepo.Update(product);
        await _unitOfWork.SaveAsync(ct);

        return Result.Success(request.IsActive ? "Product activated." : "Product deactivated.");
    }
}

