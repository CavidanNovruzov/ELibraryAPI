using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.DeleteProductImage;

public sealed class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductImageCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductImageCommandRequest request, CancellationToken ct)
    {
        var productImageReadRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductImage, Guid>();
        var productImageWriteRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductImage, Guid>();

        var productImage = await productImageReadRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productImage == null)
        {
            return Result.Failure("Product image not found.");
        }

        productImage.IsDeleted = true;
        productImageWriteRepository.Update(productImage);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Product image deleted successfully.");
    }
}