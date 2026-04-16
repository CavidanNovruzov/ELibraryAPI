using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PromoCode.CreatePromoCode;

public sealed class CreatePromoCodeCommandHandler : IRequestHandler<CreatePromoCodeCommandRequest, Result<CreatePromoCodeCommandResponse>>
{
    public Task<Result<CreatePromoCodeCommandResponse>> Handle(CreatePromoCodeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
