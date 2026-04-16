using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.ProductAuthor.DeleteProductAuthor;

public sealed record DeleteProductAuthorCommandRequest(Guid Id) : IRequest<Result>;
