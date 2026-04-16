using ELibraryAPI.Application.Abstractions.Repositories;
using ELibraryAPI.Application.Abstractions.Repositories.Auth;
using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Application.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    // Spesifik metodları olan repository-lər
    IRefreshTokenReadRepository RefreshTokenRead { get; }
    IRefreshTokenWriteRepository RefreshTokenWrite { get; }

    // Bütün digər entity-lər üçün generic giriş
    IReadRepository<T, TKey> ReadRepository<T, TKey>() where T : class, IEntity<TKey>;
    IWriteRepository<T, TKey> WriteRepository<T, TKey>() where T : class, IEntity<TKey>;

    Task<int> SaveAsync(CancellationToken ct = default);
}


//public interface IUnitOfWork : IAsyncDisposable
//{
//    // --- Entity Repositories ---
//    IAuthorReadRepository AuthorRead { get; }
//    IAuthorWriteRepository AuthorWrite { get; }
//    IBannerReadRepository BannerRead { get; }
//    IBannerWriteRepository BannerWrite { get; }
//    IBasketItemReadRepository BasketItemRead { get; }
//    IBasketItemWriteRepository BasketItemWrite { get; }
//    IBasketReadRepository BasketRead { get; }
//    IBasketWriteRepository BasketWrite { get; }
//    IBranchReadRepository BranchRead { get; }
//    IBranchWriteRepository BranchWrite { get; }
//    IBranchWorkHoursReadRepository BranchWorkHoursRead { get; }
//    IBranchWorkHoursWriteRepository BranchWorkHoursWrite { get; }
//    ICampaignReadRepository CampaignRead { get; }
//    ICampaignWriteRepository CampaignWrite { get; }
//    ICategoryReadRepository CategoryRead { get; }
//    ICategoryWriteRepository CategoryWrite { get; }
//    ICoverTypeReadRepository CoverTypeRead { get; }
//    ICoverTypeWriteRepository CoverTypeWrite { get; }
//    IGenreReadRepository GenreRead { get; }
//    IGenreWriteRepository GenreWrite { get; }
//    IInventoryMovementReadRepository InventoryMovementRead { get; }
//    IInventoryMovementWriteRepository InventoryMovementWrite { get; }
//    ILanguageReadRepository LanguageRead { get; }
//    ILanguageWriteRepository LanguageWrite { get; }
//    IOrderItemReadRepository OrderItemRead { get; }
//    IOrderItemWriteRepository OrderItemWrite { get; }
//    IOrderReadRepository OrderRead { get; }
//    IOrderWriteRepository OrderWrite { get; }
//    IOrderStatusReadRepository OrderStatusRead { get; }
//    IOrderStatusWriteRepository OrderStatusWrite { get; }
//    IPaymentMethodReadRepository PaymentMethodRead { get; }
//    IPaymentMethodWriteRepository PaymentMethodWrite { get; }
//    IPriceHistoryReadRepository PriceHistoryRead { get; }
//    IPriceHistoryWriteRepository PriceHistoryWrite { get; }
//    IProductAuthorReadRepository ProductAuthorRead { get; }
//    IProductAuthorWriteRepository ProductAuthorWrite { get; }
//    IProductGenreReadRepository ProductGenreRead { get; }
//    IProductGenreWriteRepository ProductGenreWrite { get; }
//    IProductImageReadRepository ProductImageRead { get; }
//    IProductImageWriteRepository ProductImageWrite { get; }
//    IProductReadRepository ProductRead { get; }
//    IProductWriteRepository ProductWrite { get; }
//    IProductTagReadRepository ProductTagRead { get; }
//    IProductTagWriteRepository ProductTagWrite { get; }
//    IReviewReadRepository ReviewRead { get; }
//    IReviewWriteRepository ReviewWrite { get; }
//    IShippingMethodReadRepository ShippingMethodRead { get; }
//    IShippingMethodWriteRepository ShippingMethodWrite { get; }
//    IStockReadRepository StockRead { get; }
//    IStockWriteRepository StockWrite { get; }
//    ISubCategoryReadRepository SubCategoryRead { get; }
//    ISubCategoryWriteRepository SubCategoryWrite { get; }
//    ITagReadRepository TagRead { get; }
//    ITagWriteRepository TagWrite { get; }
//    ITransactionReadRepository TransactionRead { get; }
//    ITransactionWriteRepository TransactionWrite { get; }
//    IUserAddressReadRepository UserAddressRead { get; }
//    IUserAddressWriteRepository UserAddressWrite { get; }
//    IUserSearchHistoryReadRepository UserSearchHistoryRead { get; }
//    IUserSearchHistoryWriteRepository UserSearchHistoryWrite { get; }
//    IWishlistItemReadRepository WishlistItemRead { get; }
//    IWishlistItemWriteRepository WishlistItemWrite { get; }
//    IWishlistReadRepository WishlistRead { get; }
//    IWishlistWriteRepository WishlistWrite { get; }

//    // --- Auth Repositories ---
//    IPermissionReadRepository PermissionRead { get; }
//    IPermissionWriteRepository PermissionWrite { get; }
//    IUserPermissionReadRepository UserPermissionRead { get; }
//    IUserPermissionWriteRepository UserPermissionWrite { get; }
//    IRolePermissionReadRepository RolePermissionRead { get; }
//    IRolePermissionWriteRepository RolePermissionWrite { get; }

//    // --- RefreshToken (Yeni Əlavə) ---
//    IRefreshTokenReadRepository RefreshTokenRead { get; }
//    IRefreshTokenWriteRepository RefreshTokenWrite { get; }

//    Task<int> SaveAsync(CancellationToken ct = default);
//}