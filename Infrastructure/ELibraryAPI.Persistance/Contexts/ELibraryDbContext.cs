
using ELibraryAPI.Domain.Entities.Common;
using global::ELibraryAPI.Domain.Entities.Concrete;
using global::ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace ELibraryAPI.Persistence.Contexts;

public class ELibraryDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ELibraryDbContext(DbContextOptions<ELibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<AppUserPermission> UserPermissions => Set<AppUserPermission>();

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Basket> Baskets => Set<Basket>();
    public DbSet<BasketItem> BasketItems => Set<BasketItem>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<BranchWorkHours> BranchWorkHours => Set<BranchWorkHours>();
    public DbSet<Campaign> Campaigns => Set<Campaign>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<CoverType> CoverTypes => Set<CoverType>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();
    public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
    public DbSet<PriceHistory> PriceHistories => Set<PriceHistory>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductAuthor> ProductAuthors => Set<ProductAuthor>();
    public DbSet<ProductGenre> ProductGenres => Set<ProductGenre>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<ProductTag> ProductTags => Set<ProductTag>();
    public DbSet<PromoCode> PromoCodes => Set<PromoCode>();
    public DbSet<Publisher> Publishers => Set<Publisher>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ShippingMethod> ShippingMethods => Set<ShippingMethod>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<SubCategory> SubCategories => Set<SubCategory>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<UserAddress> UserAddresses => Set<UserAddress>();
    public DbSet<UserSearchHistory> UserSearchHistories => Set<UserSearchHistory>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<WishlistItem> WishlistItems => Set<WishlistItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.ApplyConfigurationsFromAssembly(typeof(ELibraryDbContext).Assembly);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // --- Global Query Filter Əlavəsi ---
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var isDeletedProperty = entityType.FindProperty("IsDeleted");

            if (isDeletedProperty != null && isDeletedProperty.ClrType == typeof(bool))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var filter = Expression.Lambda(
                    Expression.Equal(
                    Expression.Property(parameter, isDeletedProperty.PropertyInfo!),
                    Expression.Constant(false)
                    ), parameter);

                // Filteri tətbiq edirik
                builder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        var now = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = now;
                entry.Entity.UpdatedDate = now;
            }
            // Mövcud data üzərində dəyişiklik (o cümlədən soft delete) olanda yalnız bu işləyir
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}


