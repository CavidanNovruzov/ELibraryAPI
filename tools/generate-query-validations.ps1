<#
Generates FluentValidation validators for generated query requests.

- Creates per-entity folders under:
  Core/ELibraryAPI.Application/Validations/Queries/<Entity>/
- Adds:
  - GetById<Entity>QueryValidator (validates Id)
  - GetAll<Entity>QueryValidator (no rules; placeholder for consistency)
- Skips files that already exist unless -Force is provided.

Usage:
  powershell -ExecutionPolicy Bypass -File .\tools\generate-query-validations.ps1
  powershell -ExecutionPolicy Bypass -File .\tools\generate-query-validations.ps1 -Force
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
$validations = Join-Path $app "Validations\Queries"

$entities = @(
  "Author","Banner","Basket","BasketItem","Branch","BranchWorkHours","Campaign","Category","CoverType",
  "Genre","InventoryMovement","Language","Order","OrderItem","OrderStatus","PaymentMethod","PriceHistory",
  "Product","ProductAuthor","ProductGenre","ProductImage","ProductTag","PromoCode","Publisher","Review",
  "ShippingMethod","Stock","SubCategory","Tag","Transaction","UserAddress","UserSearchHistory","Wishlist","WishlistItem",
  "Permission","RolePermission","AppUserPermission","RefreshToken"
)

foreach ($entity in $entities) {
  $dir = Join-Path $validations $entity
  Ensure-Dir $dir

  # Id type mapping
  $idRule =
    switch ($entity) {
      "Permission" { "        RuleFor(x => x.Id).GreaterThan(0);" }
      default { "        RuleFor(x => x.Id).NotEmpty();" }
    }

  $byIdNs = "ELibraryAPI.Application.Validations.Queries.$entity"
  $byIdUsingNs = "ELibraryAPI.Application.Features.Queries.$entity.GetById$entity"
  $byIdClass = "GetById${entity}QueryValidator"
  $byIdReq = "GetById${entity}QueryRequest"
  $byIdPath = Join-Path $dir "$byIdClass.cs"

  Write-FileIfMissing $byIdPath (Cs(@"
using $byIdUsingNs;
using FluentValidation;

namespace $byIdNs;

public sealed class $byIdClass : AbstractValidator<$byIdReq>
{
    public $byIdClass()
    {
$idRule
    }
}
"@))

  $allUsingNs = "ELibraryAPI.Application.Features.Queries.$entity.GetAll$entity"
  $allClass = "GetAll${entity}QueryValidator"
  $allReq = "GetAll${entity}QueryRequest"
  $allPath = Join-Path $dir "$allClass.cs"

  Write-FileIfMissing $allPath (Cs(@"
using $allUsingNs;
using FluentValidation;

namespace $byIdNs;

public sealed class $allClass : AbstractValidator<$allReq>
{
    public $allClass()
    {
        // No input to validate (placeholder for consistency)
    }
}
"@))
}

Write-Host "Done. Use -Force to overwrite existing files."

