<# 
Generates CQRS command scaffolding + FluentValidation validators for all Domain entities.

- Creates (if missing) per-entity folders under:
  Core/ELibraryAPI.Application/Features/Commands/<Entity>/{Create<Entity>,Update<Entity>,Delete<Entity>}/
  Core/ELibraryAPI.Application/Validations/<Entity>/
- Generates 3 files per operation (Request/Response/Handler) and 1 validator per request.
- Skips files that already exist unless -Force is provided.

Usage (PowerShell):
  pwsh .\tools\generate-cqrs-and-validations.ps1
  pwsh .\tools\generate-cqrs-and-validations.ps1 -Force
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
$features = Join-Path $app "Features\Commands"
$validations = Join-Path $app "Validations"

# Domain entities list (Concrete + Auth)
$entities = @(
  "Author","Banner","Basket","BasketItem","Branch","BranchWorkHours","Campaign","Category","CoverType",
  "Genre","InventoryMovement","Language","Order","OrderItem","OrderStatus","PaymentMethod","PriceHistory",
  "Product","ProductAuthor","ProductGenre","ProductImage","ProductTag","PromoCode","Publisher","Review",
  "ShippingMethod","Stock","SubCategory","Tag","Transaction","UserAddress","UserSearchHistory","Wishlist","WishlistItem",
  "Permission","RolePermission","AppUserPermission","RefreshToken"
)

# Validation rules based on existing EF configurations / typical bookstore backend rules.
# Keys: field name -> rule snippet lines (FluentValidation)
$rules = @{
  "Author" = @{
    "FullName"="NotEmpty().MaximumLength(200)";
    "Biography"="NotEmpty()";
    "ImagePath"="NotEmpty().MaximumLength(1000)";
    "Country"="NotEmpty().MaximumLength(100)";
  };
  "Banner" = @{
    "ImageUrl"="NotEmpty().MaximumLength(1000)";
    "RedirectUrl"="NotEmpty().MaximumLength(1000)";
  };
  "Category" = @{ "Name"="NotEmpty().MaximumLength(200)" };
  "SubCategory" = @{ "Name"="NotEmpty().MaximumLength(200)"; "CategoryId"="NotEmpty()" };
  "CoverType" = @{ "Name"="NotEmpty().MaximumLength(100)" };
  "Language" = @{ "Name"="NotEmpty().MaximumLength(100)"; "Code"="NotEmpty().MaximumLength(10)" };
  "Genre" = @{ "Name"="NotEmpty().MaximumLength(200)" };
  "Tag" = @{ "Name"="NotEmpty().MaximumLength(100)" };
  "Publisher" = @{ "Name"="NotEmpty().MaximumLength(200)"; "Description"="NotEmpty()" };
  "Campaign" = @{ "Title"="NotEmpty().MaximumLength(200)"; "Description"="NotEmpty()"; "DiscountPercent"="InclusiveBetween(0,100)" };
  "PromoCode" = @{
    "Code"="NotEmpty().MaximumLength(50)";
    "DiscountPercent"="InclusiveBetween(0,100)";
    "StartDate"="NotEmpty()";
    "EndDate"="NotEmpty().GreaterThan(x => x.StartDate)";
    "UsageLimit"="GreaterThanOrEqualTo(0)";
  };
  "ShippingMethod" = @{ "Name"="NotEmpty().MaximumLength(100)"; "Price"="GreaterThanOrEqualTo(0)" };
  "PaymentMethod" = @{ "Name"="NotEmpty().MaximumLength(100)" };
  "OrderStatus" = @{ "Name"="NotEmpty().MaximumLength(100)" };
  "Review" = @{
    "ProductId"="NotEmpty()";
    "UserId"="NotEmpty()";
    "Comment"="NotEmpty().MaximumLength(2000)";
    "Raiting"="InclusiveBetween(1,5)";
  };
  "BasketItem" = @{ "BasketId"="NotEmpty()"; "ProductId"="NotEmpty()"; "Quantity"="GreaterThan(0)" };
  "Basket" = @{ "UserId"="NotEmpty()"; "TotalPrice"="GreaterThanOrEqualTo(0)" };
  "Wishlist" = @{ "UserId"="NotEmpty()" };
  "WishlistItem" = @{ "WishlistId"="NotEmpty()"; "ProductId"="NotEmpty()" };
  "UserAddress" = @{ "UserId"="NotEmpty()"; "AddressLine"="NotEmpty().MaximumLength(1000)" };
  "UserSearchHistory" = @{ "UserId"="NotEmpty()"; "SearchQuery"="NotEmpty().MaximumLength(500)" };
  "Branch" = @{ "Name"="NotEmpty().MaximumLength(200)"; "Location"="NotEmpty().MaximumLength(500)"; "Phone"="NotEmpty().MaximumLength(30)" };
  "BranchWorkHours" = @{
    "BranchId"="NotEmpty()";
    "Day"="IsInEnum()";
    "OpenTime"="NotEmpty()";
    "CloseTime"="NotEmpty().GreaterThan(x => x.OpenTime)";
  };
  "Stock" = @{ "ProductId"="NotEmpty()"; "BranchId"="NotEmpty()"; "Quantity"="GreaterThanOrEqualTo(0)" };
  "InventoryMovement" = @{
    "ProductId"="NotEmpty()";
    "FromBranchId"="NotEmpty()";
    "ToBranchId"="NotEmpty().NotEqual(x => x.FromBranchId)";
    "Quantity"="GreaterThan(0)";
    "Type"="NotEmpty().MaximumLength(50)";
  };
  "Order" = @{
    "OrderNumber"="NotEmpty().MaximumLength(50)";
    "UserId"="NotEmpty()";
    "OrderStatusId"="NotEmpty()";
    "PaymentMethodId"="NotEmpty()";
    "ShippingMethodId"="NotEmpty()";
    "TotalAmount"="GreaterThanOrEqualTo(0)";
    "OrderNote"="NotEmpty().MaximumLength(1000)";
  };
  "OrderItem" = @{ "OrderId"="NotEmpty()"; "ProductId"="NotEmpty()"; "Quantity"="GreaterThan(0)"; "UnitPrice"="GreaterThanOrEqualTo(0)" };
  "Transaction" = @{
    "OrderId"="NotEmpty()";
    "Amount"="GreaterThanOrEqualTo(0)";
    "TransactionId"="NotEmpty().MaximumLength(200)";
    "ProviderResponse"="NotEmpty()";
  };
  "PriceHistory" = @{ "ProductId"="NotEmpty()"; "OldPrice"="GreaterThanOrEqualTo(0)"; "NewPrice"="GreaterThanOrEqualTo(0)" };
  "Product" = @{
    "Title"="NotEmpty().MaximumLength(250)";
    "Description"="NotEmpty()";
    "ISBN"="NotEmpty().MaximumLength(20)";
    "PageCount"="GreaterThan(0)";
    "SalePrice"="GreaterThanOrEqualTo(0)";
    "DiscountPrice"="GreaterThanOrEqualTo(0).LessThanOrEqualTo(x => x.SalePrice).When(x => x.DiscountPrice != null)";
    "PublisherId"="NotEmpty()";
    "LanguageId"="NotEmpty()";
    "CoverTypeId"="NotEmpty()";
    "SubCategoryId"="NotEmpty()";
  };
  "ProductImage" = @{ "ImageUrl"="NotEmpty().MaximumLength(1000)"; "ProductId"="NotEmpty()" };
  "ProductAuthor" = @{ "ProductId"="NotEmpty()"; "AuthorId"="NotEmpty()" };
  "ProductGenre" = @{ "ProductId"="NotEmpty()"; "GenreId"="NotEmpty()" };
  "ProductTag" = @{ "ProductId"="NotEmpty()"; "TagId"="NotEmpty()" };
  # Auth-related
  "Permission" = @{ "Key"="NotEmpty().MaximumLength(150)" };
  "RolePermission" = @{ "RoleId"="NotEmpty()"; "PermissionId"="GreaterThan(0)" };
  "AppUserPermission" = @{ "UserId"="NotEmpty()"; "PermissionId"="GreaterThan(0)" };
  "RefreshToken" = @{ "UserId"="NotEmpty()"; "TokenHash"="NotEmpty().MaximumLength(512)"; "ExpiresAt"="NotEmpty()" };
}

function New-ValidatorContent([string]$Entity, [string]$Op, [string]$RequestNs, [string]$RequestType, [hashtable]$entityRules, [string[]]$fields) {
  $ns = "ELibraryAPI.Application.Validations.$Entity"
  $using = @(
    "using $RequestNs;",
    "using FluentValidation;",
    "",
    "namespace $ns;",
    "",
    "public sealed class ${Op}${Entity}CommandValidator : AbstractValidator<$RequestType>",
    "{",
    "    public ${Op}${Entity}CommandValidator()",
    "    {"
  )

  if ($Op -eq "Update") {
    $using += "        RuleFor(x => x.Id).NotEmpty();"
    $using += ""
  }
  if ($Op -eq "Delete") {
    $using += "        RuleFor(x => x.Id).NotEmpty();"
  } else {
    foreach ($f in $fields) {
      if ($entityRules.ContainsKey($f)) {
        $rule = $entityRules[$f]
        $using += "        RuleFor(x => x.$f).$rule;"
      }
    }
  }

  $using += @(
    "    }",
    "}",
    ""
  )
  return Cs(($using -join "`n"))
}

function New-RequestContent([string]$Entity, [string]$Op, [string]$requestNs, [string]$responseType, [string[]]$fields) {
  $props = @()
  foreach ($f in $fields) {
    # simple type inference
    $type =
      switch -Regex ($f) {
        "Id$" { "Guid" ; break }
        "UserId$" { "Guid" ; break }
        "PermissionId$" { "int" ; break }
        "DiscountPercent$" { "decimal" ; break }
        "Price$|Amount$|SalePrice$|DiscountPrice$|TotalAmount$|OldPrice$|NewPrice$|UnitPrice$" { "decimal" ; break }
        "PageCount$|Quantity$|UsageLimit$|Raiting$" { "int" ; break }
        "StartDate$|EndDate$|ExpiresAt$" { "DateTime" ; break }
        "IsMain$|IsSuccess$|IsDelegatable$" { "bool" ; break }
        "OpenTime$|CloseTime$" { "TimeSpan" ; break }
        "Day$" { "DayOfWeek" ; break }
        default { "string" }
      }

    if ($type -eq "decimal" -and $f -eq "DiscountPrice") { $type = "decimal?" }

    $props += "    $type $f"
  }

  if ($Op -eq "Update") { $props = @("    Guid Id") + $props }
  if ($Op -eq "Delete") { $props = @("    Guid Id") }

  $params = ($props -join ",`n")
  $requestType = "${Op}${Entity}CommandRequest"

  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $requestNs;

public sealed record $requestType(
$params
) : IRequest<Result<$responseType>>;
"@)
}

function New-ResponseContent([string]$Entity, [string]$Op, [string]$ns) {
  $type = "${Op}${Entity}CommandResponse"
  $body =
    switch ($Op) {
      "Create" { "public sealed record $type(Guid Id);" }
      "Update" { "public sealed record $type(Guid Id);" }
      default  { "public sealed record $type;" }
    }
  return Cs(@"
namespace $ns;

$body
"@)
}

function New-HandlerContent([string]$Entity, [string]$Op, [string]$ns, [string]$requestType, [string]$responseType) {
  return Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed class ${Op}${Entity}CommandHandler : IRequestHandler<$requestType, Result<$responseType>>
{
    public Task<Result<$responseType>> Handle($requestType request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
"@)
}

foreach ($entity in $entities) {
  $entityRules = $rules[$entity]
  if (-not $entityRules) {
    # default: only validates Id on update/delete; create/update will be basic (no rules)
    $entityRules = @{}
  }

  $fields = @($entityRules.Keys | Sort-Object)

  foreach ($op in @("Create","Update","Delete")) {
    $ns = "ELibraryAPI.Application.Features.Commands.$entity.${op}${entity}"
    $dir = Join-Path $features "$entity\${op}${entity}"
    Ensure-Dir $dir

    $requestType = "${op}${entity}CommandRequest"
    $responseType = "${op}${entity}CommandResponse"

    $requestPath = Join-Path $dir "${requestType}.cs"
    $responsePath = Join-Path $dir "${responseType}.cs"
    $handlerPath = Join-Path $dir "${op}${entity}CommandHandler.cs"

    $validatorDir = Join-Path $validations $entity
    $validatorPath = Join-Path $validatorDir "${op}${entity}CommandValidator.cs"

    if ($op -eq "Delete") {
      # Delete uses non-generic Result (no payload)
      $deleteNs = "ELibraryAPI.Application.Features.Commands.$entity.Delete$entity"
      $ns = $deleteNs
      $responseType = "Result"
    }

    $reqContent = New-RequestContent -Entity $entity -Op $op -requestNs $ns -responseType $responseType -fields $fields
    if ($op -eq "Delete") {
      $reqContent = Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed record ${op}${entity}CommandRequest(Guid Id) : IRequest<Result>;
"@)
    }

    Write-FileIfMissing $requestPath $reqContent

    if ($op -ne "Delete") {
      Write-FileIfMissing $responsePath (New-ResponseContent -Entity $entity -Op $op -ns $ns)
      Write-FileIfMissing $handlerPath (New-HandlerContent -Entity $entity -Op $op -ns $ns -requestType $requestType -responseType $responseType)
    } else {
      # Delete has no response type file
      Write-FileIfMissing $handlerPath (Cs(@"
using ELibraryAPI.Application.Responses;
using MediatR;

namespace $ns;

public sealed class Delete${entity}CommandHandler : IRequestHandler<Delete${entity}CommandRequest, Result>
{
    public Task<Result> Handle(Delete${entity}CommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
"@))
    }

    $validatorContent = New-ValidatorContent -Entity $entity -Op $op -RequestNs $ns -RequestType $requestType -entityRules $entityRules -fields $fields
    Write-FileIfMissing $validatorPath $validatorContent
  }
}

Write-Host "Done. Use -Force to overwrite existing files."

