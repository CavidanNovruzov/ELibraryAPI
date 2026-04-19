using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.DeleteProductTag;

public sealed class DeleteProductTagCommandHandler : IRequestHandler<DeleteProductTagCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductTagCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductTagCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductTag, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductTag, Guid>();

        var productTag = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productTag == null)
        {
            return Result.Failure("Product-Tag relation not found.");
        }

        productTag.IsDeleted = true;
        writeRepository.Update(productTag);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Tag removed from product successfully.");
    }
}