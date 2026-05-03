using ELibraryAPI.Application.Features.Commands.ProductImage.CreateProductImage;
using ELibraryAPI.Application.Features.Commands.ProductImage.DeleteProductImage;
using ELibraryAPI.Application.Features.Commands.ProductImage.UpdateProductImage;
using ELibraryAPI.Application.Features.Queries.ProductImage.GetAllProductImage;
using ELibraryAPI.Application.Features.Queries.ProductImage.GetByIdProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/product-images")]
public sealed class ProductImagesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProductImagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllProductImageQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdProductImageQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductImageCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductImageCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteProductImageCommandRequest(id), ct));
}

