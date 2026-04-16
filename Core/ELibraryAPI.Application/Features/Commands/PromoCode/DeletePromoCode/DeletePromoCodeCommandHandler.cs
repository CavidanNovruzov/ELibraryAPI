using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PromoCode.DeletePromoCode;

public sealed class DeletePromoCodeCommandHandler : IRequestHandler<DeletePromoCodeCommandRequest, Result>
{
    public Task<Result> Handle(DeletePromoCodeCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
