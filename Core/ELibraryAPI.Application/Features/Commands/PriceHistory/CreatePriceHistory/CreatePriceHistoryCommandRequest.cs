using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.CreatePriceHistory;

public sealed record CreatePriceHistoryCommandRequest(
    decimal NewPrice,
    decimal OldPrice,
    Guid ProductId
) : IRequest<Result<CreatePriceHistoryCommandResponse>>;
