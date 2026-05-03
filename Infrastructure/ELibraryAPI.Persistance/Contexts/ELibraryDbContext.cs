using ELibraryAPI.Application.Abstractions.Services;
using ELibraryAPI.Domain.Entities.Common;
using global::ELibraryAPI.Domain.Entities.Concrete;
using global::ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Linq.Expressions;
using System.Reflection;

namespace ELibraryAPI.Persistence.Contexts;

public class ELibraryDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    private readonly ICurrentUserService _currentUserService;

    public ELibraryDbContext(
        DbContextOptions<ELibraryDbContext> options,
        ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    #region Auth & Security Sets
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<AppUserPermission> UserPermissions => Set<AppUserPermission>();
    #endregion

    #region Business Logic Sets
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
    public DbSet<ProductCampaign> ProductCampaigns => Set<ProductCampaign>(); 
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
    #endregion

    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        ApplyBusinessLogic();
        return await base.SaveChangesAsync(ct);
    }

    public override int SaveChanges()
    {
        ApplyBusinessLogic();
        return base.SaveChanges();
    }

    private void ApplyBusinessLogic()
    {
        var entries = ChangeTracker.Entries();

        var currentUserId = _currentUserService.UserId ?? "System";
        var currentUserGuid = _currentUserService.UserGuid;

        foreach (var entry in entries)
        {

            if (entry.Entity is IAuditEntity auditEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    auditEntity.CreatedDate = DateTime.UtcNow;
                    auditEntity.CreatedBy = currentUserId;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditEntity.UpdatedDate = DateTime.UtcNow;
                    auditEntity.UpdatedBy = currentUserId;
                }
            }

            if (entry.Entity is ISoftDelete softDeleteEntity && entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                softDeleteEntity.IsDeleted = true;


                if (entry.Entity is IAuditEntity audit)
                {
                    audit.UpdatedDate = DateTime.UtcNow;
                    audit.UpdatedBy = currentUserId;
                }
            }
            if (entry.Entity is IOwnership ownership && entry.State == EntityState.Added)
            {
                if (ownership.UserId == Guid.Empty)
                {
                    ownership.UserId = currentUserGuid;
                }
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var parameter = Expression.Parameter(entityType.ClrType, "e");
            List<Expression> filterExpressions = new();

            // 1. Soft Delete Filtri
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var isDeletedProp = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                filterExpressions.Add(Expression.Equal(isDeletedProp, Expression.Constant(false)));
            }

            // 2. Dinamik Ownership Filtri
            if (typeof(IOwnership).IsAssignableFrom(entityType.ClrType))
            {
                var userIdProp = Expression.Property(parameter, nameof(IOwnership.UserId));

                // DİQQƏT: Burada Expression.Property vasitəsilə service-in UserGuid mülkiyyətinə bağlanırıq
                // Bu, EF-ə deyir ki: "Hər sorğuda get bu service-dən o anki Guid-i götür"
                var serviceInstance = Expression.Constant(_currentUserService);
                var currentUserIdProp = Expression.Property(serviceInstance, nameof(ICurrentUserService.UserGuid));

                filterExpressions.Add(Expression.Equal(userIdProp, currentUserIdProp));
            }

            if (filterExpressions.Count > 0)
            {
                // Bütün filterləri (SoftDelete + Ownership) AND ilə birləşdiririk
                var combinedBody = filterExpressions.Aggregate(Expression.AndAlso);
                var lambda = Expression.Lambda(combinedBody, parameter);

                builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
        {
            builder.AddSerilog();

            builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name 
                && level == LogLevel.Information);                 
        }));

        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
    }
}