using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.DeleteProductImage;

public sealed record DeleteProductImageCommandRequest(Guid Id) : IRequest<Result>;
