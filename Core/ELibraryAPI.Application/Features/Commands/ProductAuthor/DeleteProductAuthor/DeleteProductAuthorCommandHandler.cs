using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.DeleteProductAuthor;

public sealed class DeleteProductAuthorCommandHandler : IRequestHandler<DeleteProductAuthorCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductAuthorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductAuthorCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductAuthor, Guid>();

        var productAuthor = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productAuthor == null)
        {
            return Result.Failure("Product-Author relation not found.");
        }

        productAuthor.IsDeleted = true;
        writeRepository.Update(productAuthor);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Author removed from product successfully.");
    }
}