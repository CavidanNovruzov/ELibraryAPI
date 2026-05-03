using ELibraryAPI.API.Controllers;
using ELibraryAPI.Application.Features.Commands.Tag.CreateTag;
using ELibraryAPI.Application.Features.Commands.Tag.DeleteTag;
using ELibraryAPI.Application.Features.Commands.Tag.UpdateTag;
using ELibraryAPI.Application.Features.Queries.Tag.GetAllTag;
using ELibraryAPI.Application.Features.Queries.Tag.GetByIdTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/tags")]
public sealed class TagsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public TagsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllTagQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdTagQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTagCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteTagCommandRequest(id), ct));
}

