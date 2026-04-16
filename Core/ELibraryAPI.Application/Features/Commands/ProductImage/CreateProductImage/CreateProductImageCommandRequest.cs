using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.CreateProductImage;

public sealed record CreateProductImageCommandRequest(
    string ImageUrl,
    Guid ProductId
) : IRequest<Result<CreateProductImageCommandResponse>>;
