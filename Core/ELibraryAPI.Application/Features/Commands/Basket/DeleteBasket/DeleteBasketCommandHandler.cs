using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;

public sealed class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBasketCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBasketCommandRequest request, CancellationToken ct)
    {
        var readRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Basket, Guid>();
        var writeRepo = _unitOfWork.WriteRepository<Domain.Entities.Concrete.Basket, Guid>();

        var basket = await readRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);

        if (basket == null)
        {
            return Result.Failure("Basket not found.");
        }

        basket.IsDeleted = true;
        writeRepo.Update(basket);

        await _unitOfWork.SaveAsync(ct);

        return Result.Success("Basket deleted successfully.");
    }
}