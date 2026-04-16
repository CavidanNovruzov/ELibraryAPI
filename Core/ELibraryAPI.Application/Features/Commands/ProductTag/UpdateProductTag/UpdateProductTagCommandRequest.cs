using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.UpdateProductTag;

public sealed record UpdateProductTagCommandRequest(
    Guid Id,
    Guid ProductId,
    Guid TagId
) : IRequest<Result<UpdateProductTagCommandResponse>>;
