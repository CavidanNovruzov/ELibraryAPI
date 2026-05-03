using ELibraryAPI.Application.Responses;
using ELibraryAPI.Application.UnitOfWork;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Wishlist.UpdateWishlist;

public sealed class UpdateWishlistCommandHandler : IRequestHandler<UpdateWishlistCommandRequest, Result<UpdateWishlistCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateWishlistCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<UpdateWishlistCommandResponse>> Handle(UpdateWishlistCommandRequest request, CancellationToken ct)
    {
        var wishlistReadRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Wishlist, Guid>();
        var userRepo = _unitOfWork.ReadRepository<Domain.Entities.Concrete.Auth.AppUser, Guid>();

        var wishlist = await wishlistReadRepo.GetByIdAsync(request.Id, tracking: true, ct: ct);
        if (wishlist == null)
            return Result<UpdateWishlistCommandResponse>.Failure("Wishlist not found.");

        if (wishlist.UserId != request.UserId)
        {
            if (!await userRepo.ExistsAsync(x => x.Id == request.UserId, false, ct))
                return Result<UpdateWishlistCommandResponse>.Failure("User not found.");

            if (await wishlistReadRepo.ExistsAsync(x => x.UserId == request.UserId && x.Id != request.Id, false, ct))
                return Result<UpdateWishlistCommandResponse>.Failure("This user already has another wishlist.");

            wishlist.UserId = request.UserId;
        }

        await _unitOfWork.SaveAsync(ct);

        return Result<UpdateWishlistCommandResponse>.Success(new(wishlist.Id), "Wishlist updated.");
    }
}
