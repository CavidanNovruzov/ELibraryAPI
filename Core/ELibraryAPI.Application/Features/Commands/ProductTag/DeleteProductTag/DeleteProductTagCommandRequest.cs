using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductTag.DeleteProductTag;

public sealed record DeleteProductTagCommandRequest(Guid Id) : IRequest<Result>;
