using ELibraryAPI.Application.Features.Commands.Review.CreateReview;
using ELibraryAPI.Application.Features.Commands.Review.DeleteReview;
using ELibraryAPI.Application.Features.Commands.Review.UpdateReview;
using ELibraryAPI.Application.Features.Queries.Review.GetAllReview;
using ELibraryAPI.Application.Features.Queries.Review.GetByIdReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/reviews")]
public sealed class ReviewsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllReviewQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdReviewQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReviewCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteReviewCommandRequest(id), ct));
}

