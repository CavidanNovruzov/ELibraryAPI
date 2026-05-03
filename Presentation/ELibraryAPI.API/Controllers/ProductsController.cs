using ELibraryAPI.Application.Features.Commands.Product.CreateProduct;
using ELibraryAPI.Application.Features.Commands.Product.DeleteProduct;
using ELibraryAPI.Application.Features.Commands.Product.SetProductActive;
using ELibraryAPI.Application.Features.Commands.Product.UpdateProduct;
using ELibraryAPI.Application.Features.Queries.Product.GetAllProduct;
using ELibraryAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/products")]
public sealed class ProductsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdProductQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteProductCommandRequest(id), ct));

    [HttpPatch("{id:guid}/active")]
    public async Task<IActionResult> SetActive([FromRoute] Guid id, [FromBody] SetProductActiveCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));
}

