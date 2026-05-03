using ELibraryAPI.Application.Features.Commands.Publisher.CreatePublisher;
using ELibraryAPI.Application.Features.Commands.Publisher.DeletePublisher;
using ELibraryAPI.Application.Features.Commands.Publisher.UpdatePublisher;
using ELibraryAPI.Application.Features.Queries.Publisher.GetAllPublisher;
using ELibraryAPI.Application.Features.Queries.Publisher.GetByIdPublisher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/publishers")]
public sealed class PublishersController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public PublishersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllPublisherQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdPublisherQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePublisherCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePublisherCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeletePublisherCommandRequest(id), ct));
}

