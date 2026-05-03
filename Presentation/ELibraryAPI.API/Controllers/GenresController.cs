using ELibraryAPI.Application.Features.Commands.Genre.CreateGenre;
using ELibraryAPI.Application.Features.Commands.Genre.DeleteGenre;
using ELibraryAPI.Application.Features.Commands.Genre.UpdateGenre;
using ELibraryAPI.Application.Features.Queries.Genre.GetAllGenre;
using ELibraryAPI.Application.Features.Queries.Genre.GetByIdGenre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/genres")]
public sealed class GenresController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public GenresController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllGenreQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdGenreQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGenreCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGenreCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteGenreCommandRequest(id), ct));
}

