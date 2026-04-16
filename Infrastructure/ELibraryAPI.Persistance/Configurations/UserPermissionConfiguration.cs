using global::ELibraryAPI.Domain.Entities.Concrete.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class UserPermissionConfiguration : IEntityTypeConfiguration<AppUserPermission>
{
    public void Configure(EntityTypeBuilder<AppUserPermission> builder)
    {

        builder.HasKey(x => new { x.UserId, x.PermissionId });

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.PermissionId)
            .IsRequired();

        builder.Property(x => x.GrantedByUserId)
            .IsRequired(false);

        builder.HasIndex(x => x.PermissionId);
        builder.HasIndex(x => x.GrantedByUserId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserPermissions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Permission)
            .WithMany(x => x.UserPermissions)
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        //builder.HasOne(x => x.GrantedByUser)
        //    .WithMany(x => x.GrantedPermissions)
        //    .HasForeignKey(x => x.GrantedByUserId)
        //    .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.GrantedByUser)
            .WithMany(x => x.GrantedPermissions)
            .HasForeignKey(x => x.GrantedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
