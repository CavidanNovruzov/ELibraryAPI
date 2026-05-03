using ELibraryAPI.Application.Features.Commands.SubCategory.CreateSubCategory;
using ELibraryAPI.Application.Features.Commands.SubCategory.DeleteSubCategory;
using ELibraryAPI.Application.Features.Commands.SubCategory.UpdateSubCategory;
using ELibraryAPI.Application.Features.Queries.SubCategory.GetAllSubCategory;
using ELibraryAPI.Application.Features.Queries.SubCategory.GetByIdSubCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/sub-categories")]
public sealed class SubCategoriesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public SubCategoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllSubCategoryQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdSubCategoryQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubCategoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSubCategoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteSubCategoryCommandRequest(id), ct));
}

