using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;

public sealed record DeleteBasketCommandRequest(Guid Id) : IRequest<Result>;
