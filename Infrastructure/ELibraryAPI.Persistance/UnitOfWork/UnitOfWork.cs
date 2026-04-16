using ELibraryAPI.Application.Abstractions.Repositories;
using ELibraryAPI.Application.Abstractions.Repositories.Auth;
using ELibraryAPI.Application.UnitOfWork;
using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Persistance.Concrete.Repositories;
using ELibraryAPI.Persistance.Concrete.Repositories.Auth;
using ELibraryAPI.Persistence.Contexts;
using System.Collections;

namespace ELibraryAPI.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ELibraryDbContext _context;
    private readonly IServiceProvider _serviceProvider; // DI-dan mövcud repository-ləri tapmaq üçün
    private Hashtable _repositories;

    public UnitOfWork(ELibraryDbContext context, IServiceProvider serviceProvider)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    // --- Xüsusi Metodları Olan Repository-lər (Həmişə Property kimi qalmalıdır) ---
    private IRefreshTokenReadRepository? _refreshTokenRead;
    public IRefreshTokenReadRepository RefreshTokenRead => _refreshTokenRead ??= new RefreshTokenReadRepository(_context);

    private IRefreshTokenWriteRepository? _refreshTokenWrite;
    public IRefreshTokenWriteRepository RefreshTokenWrite => _refreshTokenWrite ??= new RefreshTokenWriteRepository(_context);


    // --- Generic Repository Factory (Sənin 40+ klasını tək-tək yazmaqdan qurtarır) ---
    public IReadRepository<T, TKey> ReadRepository<T, TKey>() where T : class, IEntity<TKey>
    {
        _repositories ??= new Hashtable();
        var type = typeof(T).Name + "Read";

        if (!_repositories.ContainsKey(type))
        {
            // Sənin Persistence-də yaratdığın xüsusi repository klasını DI-dan tapmağa çalışır
            var repositoryInstance = _serviceProvider.GetService(typeof(IReadRepository<T, TKey>))
                                     ?? new ReadRepository<T, TKey>(_context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IReadRepository<T, TKey>)_repositories[type]!;
    }

    public IWriteRepository<T, TKey> WriteRepository<T, TKey>() where T : class, IEntity<TKey>
    {
        _repositories ??= new Hashtable();
        var type = typeof(T).Name + "Write";

        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = _serviceProvider.GetService(typeof(IWriteRepository<T, TKey>))
                                     ?? new WriteRepository<T, TKey>(_context);

            _repositories.Add(type, repositoryInstance);
        }

        return (IWriteRepository<T, TKey>)_repositories[type]!;
    }

    // --- Save & Dispose ---
    public async Task<int> SaveAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);

    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
}


//public class UnitOfWork : IUnitOfWork
//{
//    private readonly ELibraryDbContext _context;

//    public UnitOfWork(ELibraryDbContext context)
//    {
//        _context = context;
//    }

//    // --- Private Backing Fields ---
//    private IAuthorReadRepository? _authorRead;
//    private IAuthorWriteRepository? _authorWrite;
//    private IBannerReadRepository? _bannerRead;
//    private IBannerWriteRepository? _bannerWrite;
//    private IBasketItemReadRepository? _basketItemRead;
//    private IBasketItemWriteRepository? _basketItemWrite;
//    private IBasketReadRepository? _basketRead;
//    private IBasketWriteRepository? _basketWrite;
//    private IBranchReadRepository? _branchRead;
//    private IBranchWriteRepository? _branchWrite;
//    private IBranchWorkHoursReadRepository? _branchWorkHoursRead;
//    private IBranchWorkHoursWriteRepository? _branchWorkHoursWrite;
//    private ICampaignReadRepository? _campaignRead;
//    private ICampaignWriteRepository? _campaignWrite;
//    private ICategoryReadRepository? _categoryRead;
//    private ICategoryWriteRepository? _categoryWrite;
//    private ICoverTypeReadRepository? _coverTypeRead;
//    private ICoverTypeWriteRepository? _coverTypeWrite;
//    private IGenreReadRepository? _genreRead;
//    private IGenreWriteRepository? _genreWrite;
//    private IInventoryMovementReadRepository? _inventoryMovementRead;
//    private IInventoryMovementWriteRepository? _inventoryMovementWrite;
//    private ILanguageReadRepository? _languageRead;
//    private ILanguageWriteRepository? _languageWrite;
//    private IOrderItemReadRepository? _orderItemRead;
//    private IOrderItemWriteRepository? _orderItemWrite;
//    private IOrderReadRepository? _orderRead;
//    private IOrderWriteRepository? _orderWrite;
//    private IOrderStatusReadRepository? _orderStatusRead;
//    private IOrderStatusWriteRepository? _orderStatusWrite;
//    private IPaymentMethodReadRepository? _paymentMethodRead;
//    private IPaymentMethodWriteRepository? _paymentMethodWrite;
//    private IPriceHistoryReadRepository? _priceHistoryRead;
//    private IPriceHistoryWriteRepository? _priceHistoryWrite;
//    private IProductAuthorReadRepository? _productAuthorRead;
//    private IProductAuthorWriteRepository? _productAuthorWrite;
//    private IProductGenreReadRepository? _productGenreRead;
//    private IProductGenreWriteRepository? _productGenreWrite;
//    private IProductImageReadRepository? _productImageRead;
//    private IProductImageWriteRepository? _productImageWrite;
//    private IProductReadRepository? _productRead;
//    private IProductWriteRepository? _productWrite;
//    private IProductTagReadRepository? _productTagRead;
//    private IProductTagWriteRepository? _productTagWrite;
//    private IReviewReadRepository? _reviewRead;
//    private IReviewWriteRepository? _reviewWrite;
//    private IShippingMethodReadRepository? _shippingMethodRead;
//    private IShippingMethodWriteRepository? _shippingMethodWrite;
//    private IStockReadRepository? _stockRead;
//    private IStockWriteRepository? _stockWrite;
//    private ISubCategoryReadRepository? _subCategoryRead;
//    private ISubCategoryWriteRepository? _subCategoryWrite;
//    private ITagReadRepository? _tagRead;
//    private ITagWriteRepository? _tagWrite;
//    private ITransactionReadRepository? _transactionRead;
//    private ITransactionWriteRepository? _transactionWrite;
//    private IUserAddressReadRepository? _userAddressRead;
//    private IUserAddressWriteRepository? _userAddressWrite;
//    private IUserSearchHistoryReadRepository? _userSearchHistoryRead;
//    private IUserSearchHistoryWriteRepository? _userSearchHistoryWrite;
//    private IWishlistItemReadRepository? _wishlistItemRead;
//    private IWishlistItemWriteRepository? _wishlistItemWrite;
//    private IWishlistReadRepository? _wishlistRead;
//    private IWishlistWriteRepository? _wishlistWrite;

//    private IPermissionReadRepository? _permissionRead;
//    private IPermissionWriteRepository? _permissionWrite;
//    private IUserPermissionReadRepository? _userPermissionRead;
//    private IUserPermissionWriteRepository? _userPermissionWrite;
//    private IRolePermissionReadRepository? _rolePermissionRead;
//    private IRolePermissionWriteRepository? _rolePermissionWrite;

//    // Auth & Token
//    private IRefreshTokenReadRepository? _refreshTokenRead;
//    private IRefreshTokenWriteRepository? _refreshTokenWrite;

//    // --- Public Properties (Expression-bodied & Null-coalescing) ---
//    public IAuthorReadRepository AuthorRead => _authorRead ??= new AuthorReadRepository(_context);
//    public IAuthorWriteRepository AuthorWrite => _authorWrite ??= new AuthorWriteRepository(_context);
//    public IBannerReadRepository BannerRead => _bannerRead ??= new BannerReadRepository(_context);
//    public IBannerWriteRepository BannerWrite => _bannerWrite ??= new BannerWriteRepository(_context);
//    public IBasketItemReadRepository BasketItemRead => _basketItemRead ??= new BasketItemReadRepository(_context);
//    public IBasketItemWriteRepository BasketItemWrite => _basketItemWrite ??= new BasketItemWriteRepository(_context);
//    public IBasketReadRepository BasketRead => _basketRead ??= new BasketReadRepository(_context);
//    public IBasketWriteRepository BasketWrite => _basketWrite ??= new BasketWriteRepository(_context);
//    public IBranchReadRepository BranchRead => _branchRead ??= new BranchReadRepository(_context);
//    public IBranchWriteRepository BranchWrite => _branchWrite ??= new BranchWriteRepository(_context);
//    public IBranchWorkHoursReadRepository BranchWorkHoursRead => _branchWorkHoursRead ??= new BranchWorkHoursReadRepository(_context);
//    public IBranchWorkHoursWriteRepository BranchWorkHoursWrite => _branchWorkHoursWrite ??= new BranchWorkHoursWriteRepository(_context);
//    public ICampaignReadRepository CampaignRead => _campaignRead ??= new CampaignReadRepository(_context);
//    public ICampaignWriteRepository CampaignWrite => _campaignWrite ??= new CampaignWriteRepository(_context);
//    public ICategoryReadRepository CategoryRead => _categoryRead ??= new CategoryReadRepository(_context);
//    public ICategoryWriteRepository CategoryWrite => _categoryWrite ??= new CategoryWriteRepository(_context);
//    public ICoverTypeReadRepository CoverTypeRead => _coverTypeRead ??= new CoverTypeReadRepository(_context);
//    public ICoverTypeWriteRepository CoverTypeWrite => _coverTypeWrite ??= new CoverTypeWriteRepository(_context);
//    public IGenreReadRepository GenreRead => _genreRead ??= new GenreReadRepository(_context);
//    public IGenreWriteRepository GenreWrite => _genreWrite ??= new GenreWriteRepository(_context);
//    public IInventoryMovementReadRepository InventoryMovementRead => _inventoryMovementRead ??= new InventoryMovementReadRepository(_context);
//    public IInventoryMovementWriteRepository InventoryMovementWrite => _inventoryMovementWrite ??= new InventoryMovementWriteRepository(_context);
//    public ILanguageReadRepository LanguageRead => _languageRead ??= new LanguageReadRepository(_context);
//    public ILanguageWriteRepository LanguageWrite => _languageWrite ??= new LanguageWriteRepository(_context);
//    public IOrderItemReadRepository OrderItemRead => _orderItemRead ??= new OrderItemReadRepository(_context);
//    public IOrderItemWriteRepository OrderItemWrite => _orderItemWrite ??= new OrderItemWriteRepository(_context);
//    public IOrderReadRepository OrderRead => _orderRead ??= new OrderReadRepository(_context);
//    public IOrderWriteRepository OrderWrite => _orderWrite ??= new OrderWriteRepository(_context);
//    public IOrderStatusReadRepository OrderStatusRead => _orderStatusRead ??= new OrderStatusReadRepository(_context);
//    public IOrderStatusWriteRepository OrderStatusWrite => _orderStatusWrite ??= new OrderStatusWriteRepository(_context);
//    public IPaymentMethodReadRepository PaymentMethodRead => _paymentMethodRead ??= new PaymentMethodReadRepository(_context);
//    public IPaymentMethodWriteRepository PaymentMethodWrite => _paymentMethodWrite ??= new PaymentMethodWriteRepository(_context);
//    public IPriceHistoryReadRepository PriceHistoryRead => _priceHistoryRead ??= new PriceHistoryReadRepository(_context);
//    public IPriceHistoryWriteRepository PriceHistoryWrite => _priceHistoryWrite ??= new PriceHistoryWriteRepository(_context);
//    public IProductAuthorReadRepository ProductAuthorRead => _productAuthorRead ??= new ProductAuthorReadRepository(_context);
//    public IProductAuthorWriteRepository ProductAuthorWrite => _productAuthorWrite ??= new ProductAuthorWriteRepository(_context);
//    public IProductGenreReadRepository ProductGenreRead => _productGenreRead ??= new ProductGenreReadRepository(_context);
//    public IProductGenreWriteRepository ProductGenreWrite => _productGenreWrite ??= new ProductGenreWriteRepository(_context);
//    public IProductImageReadRepository ProductImageRead => _productImageRead ??= new ProductImageReadRepository(_context);
//    public IProductImageWriteRepository ProductImageWrite => _productImageWrite ??= new ProductImageWriteRepository(_context);
//    public IProductReadRepository ProductRead => _productRead ??= new ProductReadRepository(_context);
//    public IProductWriteRepository ProductWrite => _productWrite ??= new ProductWriteRepository(_context);
//    public IProductTagReadRepository ProductTagRead => _productTagRead ??= new ProductTagReadRepository(_context);
//    public IProductTagWriteRepository ProductTagWrite => _productTagWrite ??= new ProductTagWriteRepository(_context);
//    public IReviewReadRepository ReviewRead => _reviewRead ??= new ReviewReadRepository(_context);
//    public IReviewWriteRepository ReviewWrite => _reviewWrite ??= new ReviewWriteRepository(_context);
//    public IShippingMethodReadRepository ShippingMethodRead => _shippingMethodRead ??= new ShippingMethodReadRepository(_context);
//    public IShippingMethodWriteRepository ShippingMethodWrite => _shippingMethodWrite ??= new ShippingMethodWriteRepository(_context);
//    public IStockReadRepository StockRead => _stockRead ??= new StockReadRepository(_context);
//    public IStockWriteRepository StockWrite => _stockWrite ??= new StockWriteRepository(_context);
//    public ISubCategoryReadRepository SubCategoryRead => _subCategoryRead ??= new SubCategoryReadRepository(_context);
//    public ISubCategoryWriteRepository SubCategoryWrite => _subCategoryWrite ??= new SubCategoryWriteRepository(_context);
//    public ITagReadRepository TagRead => _tagRead ??= new TagReadRepository(_context);
//    public ITagWriteRepository TagWrite => _tagWrite ??= new TagWriteRepository(_context);
//    public ITransactionReadRepository TransactionRead => _transactionRead ??= new TransactionReadRepository(_context);
//    public ITransactionWriteRepository TransactionWrite => _transactionWrite ??= new TransactionWriteRepository(_context);
//    public IUserAddressReadRepository UserAddressRead => _userAddressRead ??= new IUserAddressReadRepository(_context);
//    public IUserAddressWriteRepository UserAddressWrite => _userAddressWrite ??= new IUserAddressWriteRepository(_context);
//    public IUserSearchHistoryReadRepository UserSearchHistoryRead => _userSearchHistoryRead ??= new UserSearchHistoryReadRepository(_context);
//    public IUserSearchHistoryWriteRepository UserSearchHistoryWrite => _userSearchHistoryWrite ??= new UserSearchHistoryWriteRepository(_context);
//    public IWishlistItemReadRepository WishlistItemRead => _wishlistItemRead ??= new WishlistItemReadRepository(_context);
//    public IWishlistItemWriteRepository WishlistItemWrite => _wishlistItemWrite ??= new WishlistItemWriteRepository(_context);
//    public IWishlistReadRepository WishlistRead => _wishlistRead ??= new WishlistReadRepository(_context);
//    public IWishlistWriteRepository WishlistWrite => _wishlistWrite ??= new WishlistWriteRepository(_context);

//    public IPermissionReadRepository PermissionRead => _permissionRead ??= new PermissionReadRepository(_context);
//    public IPermissionWriteRepository PermissionWrite => _permissionWrite ??= new PermissionWriteRepository(_context);
//    public IUserPermissionReadRepository UserPermissionRead => _userPermissionRead ??= new UserPermissionReadRepository(_context);
//    public IUserPermissionWriteRepository UserPermissionWrite => _userPermissionWrite ??= new UserPermissionWriteRepository(_context);
//    public IRolePermissionReadRepository RolePermissionRead => _rolePermissionRead ??= new RolePermissionReadRepository(_context);
//    public IRolePermissionWriteRepository RolePermissionWrite => _rolePermissionWrite ??= new RolePermissionWriteRepository(_context);

//    // RefreshToken Implementasiyası
//    public IRefreshTokenReadRepository RefreshTokenRead => _refreshTokenRead ??= new RefreshTokenReadRepository(_context);
//    public IRefreshTokenWriteRepository RefreshTokenWrite => _refreshTokenWrite ??= new RefreshTokenWriteRepository(_context);

//    public async Task<int> SaveAsync(CancellationToken ct = default) => await _context.SaveChangesAsync(ct);

//    public async ValueTask DisposeAsync() => await _context.DisposeAsync();
//}