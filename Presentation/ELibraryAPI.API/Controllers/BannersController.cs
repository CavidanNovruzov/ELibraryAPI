using ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;
using ELibraryAPI.Application.Features.Commands.Banner.DeleteBanner;
using ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;
using ELibraryAPI.Application.Features.Queries.Banner.GetAllBanner;
using ELibraryAPI.Domain.Constants;
using ELibraryAPI.Infrastructure.Security.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/[controller]")]
public sealed class BannersController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public BannersController(IMediator mediator) => _mediator = mediator;
  
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllBannerQueryRequest(), ct));

    [HttpPost]
    [HasPermission(AuthorizePermissions.Marketing.ManageBanners)]
    public async Task<IActionResult> Create([FromBody] CreateBannerCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    [HasPermission(AuthorizePermissions.Marketing.ManageBanners)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBannerCommandRequest request, CancellationToken ct)
    {
        if (id != request.Id)
            return BadRequest("ID mismatch");

        return FromResult(await _mediator.Send(request, ct));
    }

    [HttpDelete("{id:guid}")]
    [HasPermission(AuthorizePermissions.Marketing.ManageBanners)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteBannerCommandRequest(id), ct));
}