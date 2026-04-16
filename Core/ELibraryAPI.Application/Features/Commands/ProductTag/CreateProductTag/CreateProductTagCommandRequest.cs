using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.CreateProductTag;

public sealed record CreateProductTagCommandRequest(
    Guid ProductId,
    Guid TagId
) : IRequest<Result<CreateProductTagCommandResponse>>;
