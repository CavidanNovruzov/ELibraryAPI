using ELibraryAPI.Application.Features.Commands.ProductTag.CreateProductTag;
using ELibraryAPI.Application.Features.Commands.ProductTag.DeleteProductTag;
using ELibraryAPI.Application.Features.Commands.ProductTag.UpdateProductTag;
using ELibraryAPI.Application.Features.Queries.ProductTag.GetAllProductTag;
using ELibraryAPI.Application.Features.Queries.ProductTag.GetByIdProductTag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/product-tags")]
public sealed class ProductTagsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProductTagsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllProductTagQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdProductTagQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductTagCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductTagCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteProductTagCommandRequest(id), ct));
}

