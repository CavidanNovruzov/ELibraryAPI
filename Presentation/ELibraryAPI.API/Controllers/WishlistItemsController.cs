using ELibraryAPI.Application.Features.Commands.WishlistItem.CreateWishlistItem;
using ELibraryAPI.Application.Features.Commands.WishlistItem.DeleteWishlistItem;
using ELibraryAPI.Application.Features.Commands.WishlistItem.UpdateWishlistItem;
using ELibraryAPI.Application.Features.Queries.WishlistItem.GetAllWishlistItem;
using ELibraryAPI.Application.Features.Queries.WishlistItem.GetByIdWishlistItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/wishlist-items")]
public sealed class WishlistItemsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public WishlistItemsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllWishlistItemQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdWishlistItemQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWishlistItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWishlistItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteWishlistItemCommandRequest(id), ct));
}

