using ELibraryAPI.Application.Features.Commands.Author.CreateAuthor;
using ELibraryAPI.Application.Features.Commands.Author.DeleteAuthor;
using ELibraryAPI.Application.Features.Commands.Author.UpdateAuthor;
using ELibraryAPI.Application.Features.Queries.Author.GetAllAuthor;
using ELibraryAPI.Application.Features.Queries.Author.GetAuthorById; 
using ELibraryAPI.Application.Features.Queries.Author.GetAuthorsByAlphabet; 
using ELibraryAPI.Infrastructure.Security.Attributes;
using ELibraryAPI.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/[controller]")]
public sealed class AuthorsController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public AuthorsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [HasPermission(AuthorizePermissions.Authors.View)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllAuthorQueryRequest(), ct));

    [HttpGet("alphabet")]
    [HasPermission(AuthorizePermissions.Authors.View)]
    public async Task<IActionResult> GetByAlphabet([FromQuery] char letter, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAuthorsByAlphabetQueryRequest(letter), ct));

    [HttpGet("{id:guid}")]
    [HasPermission(AuthorizePermissions.Authors.View)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAuthorByIdQueryRequest(id), ct));

    [HttpPost]
    [HasPermission(AuthorizePermissions.Authors.Create)]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    [HasPermission(AuthorizePermissions.Authors.Edit)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorCommandRequest request, CancellationToken ct)
    {
        request = request with { Id = id };
        return FromResult(await _mediator.Send(request, ct));
    }

    [HttpDelete("{id:guid}")]
    [HasPermission(AuthorizePermissions.Authors.Delete)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteAuthorCommandRequest(id), ct));
}