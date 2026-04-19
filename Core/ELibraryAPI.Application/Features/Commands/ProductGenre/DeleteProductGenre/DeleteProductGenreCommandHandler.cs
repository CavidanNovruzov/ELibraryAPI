using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductGenre.DeleteProductGenre;

public sealed class DeleteProductGenreCommandHandler : IRequestHandler<DeleteProductGenreCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductGenreCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductGenreCommandRequest request, CancellationToken ct)
    {
        var readRepository = _unitOfWork.ReadRepository<Domain.Entities.Concrete.ProductGenre, Guid>();
        var writeRepository = _unitOfWork.WriteRepository<Domain.Entities.Concrete.ProductGenre, Guid>();

        var productGenre = await readRepository.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (productGenre == null)
        {
            return Result.Failure("Product-Genre relation not found.");
        }

        productGenre.IsDeleted = true;
        writeRepository.Update(productGenre);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Genre removed from product successfully.");
    }
}