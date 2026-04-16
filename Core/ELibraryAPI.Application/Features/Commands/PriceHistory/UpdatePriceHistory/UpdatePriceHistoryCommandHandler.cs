using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.UpdatePriceHistory;

public sealed class UpdatePriceHistoryCommandHandler : IRequestHandler<UpdatePriceHistoryCommandRequest, Result<UpdatePriceHistoryCommandResponse>>
{
    public Task<Result<UpdatePriceHistoryCommandResponse>> Handle(UpdatePriceHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
