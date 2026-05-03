using ELibraryAPI.Application.Features.Commands.ProductAuthor.CreateProductAuthor;
using ELibraryAPI.Application.Features.Commands.ProductAuthor.DeleteProductAuthor;
using ELibraryAPI.Application.Features.Commands.ProductAuthor.UpdateProductAuthor;
using ELibraryAPI.Application.Features.Queries.ProductAuthor.GetAllProductAuthor;
using ELibraryAPI.Application.Features.Queries.ProductAuthor.GetByIdProductAuthor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/product-authors")]
public sealed class ProductAuthorsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProductAuthorsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllProductAuthorQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdProductAuthorQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductAuthorCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductAuthorCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteProductAuthorCommandRequest(id), ct));
}

