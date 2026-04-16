using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.PriceHistory.DeletePriceHistory;

public sealed record DeletePriceHistoryCommandRequest(Guid Id) : IRequest<Result>;
