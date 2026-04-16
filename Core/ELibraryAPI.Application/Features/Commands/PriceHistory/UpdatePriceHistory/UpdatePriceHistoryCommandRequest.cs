using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.UpdatePriceHistory;

public sealed record UpdatePriceHistoryCommandRequest(
    Guid Id,
    decimal NewPrice,
    decimal OldPrice,
    Guid ProductId
) : IRequest<Result<UpdatePriceHistoryCommandResponse>>;
