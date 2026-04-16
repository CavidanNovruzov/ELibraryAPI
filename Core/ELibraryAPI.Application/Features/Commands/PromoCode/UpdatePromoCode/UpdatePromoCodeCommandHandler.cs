using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PromoCode.UpdatePromoCode;

public sealed class UpdatePromoCodeCommandHandler : IRequestHandler<UpdatePromoCodeCommandRequest, Result<UpdatePromoCodeCommandResponse>>
{
    public Task<Result<UpdatePromoCodeCommandResponse>> Handle(UpdatePromoCodeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
