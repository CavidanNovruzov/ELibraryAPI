using global::ELibraryAPI.Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ELibraryAPI.Persistence.Configurations;

public sealed class InventoryMovementConfiguration : BaseEntityConfiguration<InventoryMovement>
{
    public override void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        base.Configure(builder);

        builder.ToTable(x =>
        {
            x.HasCheckConstraint("CK_InventoryMovements_Quantity_Positive", "[Quantity] > 0");
            x.HasCheckConstraint("CK_InventoryMovements_FromToBranchDifferent", "[FromBranchId] <> [ToBranchId]");
        });

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.FromBranchId)
            .IsRequired();

        builder.Property(x => x.ToBranchId)
            .IsRequired();

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(x => x.ProductId);
        builder.HasIndex(x => x.FromBranchId);
        builder.HasIndex(x => x.ToBranchId);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.InventoryMovements)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FromBranch)
            .WithMany(x => x.OutgoingInventoryMovements)
            .HasForeignKey(x => x.FromBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ToBranch)
            .WithMany(x => x.IncomingInventoryMovements)
            .HasForeignKey(x => x.ToBranchId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
