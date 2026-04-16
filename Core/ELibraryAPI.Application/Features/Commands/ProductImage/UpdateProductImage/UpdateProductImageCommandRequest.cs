using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductImage.UpdateProductImage;

public sealed record UpdateProductImageCommandRequest(
    Guid Id,
    string ImageUrl,
    Guid ProductId
) : IRequest<Result<UpdateProductImageCommandResponse>>;
