using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.DeletePriceHistory;

public sealed class DeletePriceHistoryCommandHandler : IRequestHandler<DeletePriceHistoryCommandRequest, Result>
{
    public Task<Result> Handle(DeletePriceHistoryCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
