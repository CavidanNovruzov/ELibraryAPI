using ELibraryAPI.Domain.Entities.Common;
using System.Runtime;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Product : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public int PageCount { get; set; }
    public decimal SalePrice { get; set; }
    public decimal? DiscountPrice { get; set; }
    public int PublicationYear { get; set; }
    public int StockCount { get; set; }
    public Guid PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;

    public Guid LanguageId { get; set; }
    public Language Language { get; set; } = null!;

    public Guid CoverTypeId { get; set; }
    public CoverType CoverType { get; set; } = null!;

    public Guid SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; } = null!;
    public ICollection<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<ProductAuthor> ProductAuthors { get; set; } = new List<ProductAuthor>();
    public ICollection<ProductGenre> ProductGenres { get; set; } = new List<ProductGenre>();
    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();
    public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
    public ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();
    public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
}

