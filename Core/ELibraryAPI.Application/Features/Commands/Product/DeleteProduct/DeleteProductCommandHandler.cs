using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Product.DeleteProduct;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Product, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Product, Guid>();

        var product = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (product == null)
        {
            return Result.Failure("Product not found.");
        }

        writeRepository.Remove(product);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Product deleted successfully.");
    }
}