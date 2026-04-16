<#
Generates CQRS query scaffolding (Request/Response/Handler) for all Domain entities.

- Creates per-entity folders under:
  Core/ELibraryAPI.Application/Features/Queries/<Entity>/{GetById<Entity>,GetAll<Entity>}/
- Generates 3 files per query (Request/Response/Handler).
- Handlers are empty (throw NotImplementedException).
- Skips files that already exist unless -Force is provided.

Usage (Windows PowerShell):
  powershell -ExecutionPolicy Bypass -File .\tools\generate-queries.ps1
  powershell -ExecutionPolicy Bypass -File .\tools\generate-queries.ps1 -Force
#>

[CmdletBinding()]
param(
  [switch]$Force
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Ensure-Dir([string]$Path) {
  if (-not (Test-Path -LiteralPath $Path)) { New-Item -ItemType Directory -Path $Path | Out-Null }
}

function Write-FileIfMissing([string]$Path, [string]$Content) {
  if ((Test-Path -LiteralPath $Path) -and -not $Force) { return }
  $dir = Split-Path -Parent $Path
  Ensure-Dir $dir
  [System.IO.File]::WriteAllText($Path, $Content, (New-Object System.Text.UTF8Encoding($false)))
}

function Cs([string]$s) { $s.Replace("`r`n","`n").Trim() + "`n" }

$root = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$app = Join-Path $root "Core\ELibraryAPI.Application"
$features = Join-Path $app "Features\Queries"

# Concrete + Auth entities
$entities = @(
  "Author","Banner","Basket","BasketItem","Branch","BranchWorkHours","Campaign","Category","CoverType",
  "Genre","InventoryMovement","Language","Order","OrderItem","OrderStatus","PaymentMethod","PriceHistory",
  "Product","ProductAuthor","ProductGenre","ProductImage","ProductTag","PromoCode","Publisher","Review",
  "ShippingMethod","Stock","SubCategory","Tag","Transaction","UserAddress","UserSearchHistory","Wishlist","WishlistItem",
  "Permission","RolePermission","AppUserPermission","RefreshToken"
)

function New-GetByIdRequest([string]$Entity, [string]$idType, [string]$ns) {
  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed record GetById${Entity}QueryRequest($idType Id) : IRequest<Result<GetById${Entity}QueryResponse>>;
"@)
}

function New-GetByIdResponse([string]$Entity, [string]$ns) {
  return Cs(@"
namespace $ns;

public sealed record GetById${Entity}QueryResponse;
"@)
}

function New-GetByIdHandler([string]$Entity, [string]$ns) {
  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed class GetById${Entity}QueryHandler : IRequestHandler<GetById${Entity}QueryRequest, Result<GetById${Entity}QueryResponse>>
{
    public Task<Result<GetById${Entity}QueryResponse>> Handle(GetById${Entity}QueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
"@)
}

function New-GetAllRequest([string]$Entity, [string]$ns) {
  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed record GetAll${Entity}QueryRequest : IRequest<Result<GetAll${Entity}QueryResponse>>;
"@)
}

function New-GetAllResponse([string]$Entity, [string]$ns) {
  return Cs(@"
namespace $ns;

public sealed record GetAll${Entity}QueryResponse;
"@)
}

function New-GetAllHandler([string]$Entity, [string]$ns) {
  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed class GetAll${Entity}QueryHandler : IRequestHandler<GetAll${Entity}QueryRequest, Result<GetAll${Entity}QueryResponse>>
{
    public Task<Result<GetAll${Entity}QueryResponse>> Handle(GetAll${Entity}QueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
"@)
}

foreach ($entity in $entities) {
  # Best-effort id type mapping
  $idType =
    switch ($entity) {
      "Permission" { "int" }
      default { "Guid" }
    }

  # GetById
  $byIdNs = "ELibraryAPI.Application.Features.Queries.$entity.GetById$entity"
  $byIdDir = Join-Path $features "$entity\GetById$entity"
  Ensure-Dir $byIdDir
  Write-FileIfMissing (Join-Path $byIdDir "GetById${entity}QueryRequest.cs") (New-GetByIdRequest $entity $idType $byIdNs)
  Write-FileIfMissing (Join-Path $byIdDir "GetById${entity}QueryResponse.cs") (New-GetByIdResponse $entity $byIdNs)
  Write-FileIfMissing (Join-Path $byIdDir "GetById${entity}QueryHandler.cs") (New-GetByIdHandler $entity $byIdNs)

  # GetAll
  $allNs = "ELibraryAPI.Application.Features.Queries.$entity.GetAll$entity"
  $allDir = Join-Path $features "$entity\GetAll$entity"
  Ensure-Dir $allDir
  Write-FileIfMissing (Join-Path $allDir "GetAll${entity}QueryRequest.cs") (New-GetAllRequest $entity $allNs)
  Write-FileIfMissing (Join-Path $allDir "GetAll${entity}QueryResponse.cs") (New-GetAllResponse $entity $allNs)
  Write-FileIfMissing (Join-Path $allDir "GetAll${entity}QueryHandler.cs") (New-GetAllHandler $entity $allNs)
}

Write-Host "Done. Use -Force to overwrite existing files."

