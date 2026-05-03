using ELibraryAPI.Application.Features.Commands.Wishlist.CreateWishlist;
using ELibraryAPI.Application.Features.Commands.Wishlist.DeleteWishlist;
using ELibraryAPI.Application.Features.Commands.Wishlist.UpdateWishlist;
using ELibraryAPI.Application.Features.Queries.Wishlist.GetAllWishlist;
using ELibraryAPI.Application.Features.Queries.Wishlist.GetByIdWishlist;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/wishlists")]
public sealed class WishlistsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public WishlistsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllWishlistQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdWishlistQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateWishlistCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWishlistCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteWishlistCommandRequest(id), ct));
}

