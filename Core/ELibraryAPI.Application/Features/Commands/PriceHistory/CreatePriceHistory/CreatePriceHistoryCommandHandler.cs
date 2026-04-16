using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.CreatePriceHistory;

public sealed class CreatePriceHistoryCommandHandler : IRequestHandler<CreatePriceHistoryCommandRequest, Result<CreatePriceHistoryCommandResponse>>
{
    public Task<Result<CreatePriceHistoryCommandResponse>> Handle(CreatePriceHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
