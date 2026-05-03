using ELibraryAPI.Domain.Entities.Common;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class PromoCode : BaseEntity, ISoftDelete
{
    public string Code { get; set; } = null!; // Məs: LIBRAFF2026
    public decimal DiscountPercent { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Limitlər
    public int UsageLimit { get; set; } // Maksimum neçə nəfər istifadə edə bilər
    public int UsageCount { get; set; } = 0; // İndiyə qədər neçə nəfər istifadə edib

    public bool IsActive { get; set; } = true;

    // Soft Delete
    public bool IsDeleted { get; set; } = false;

    // Navigation Property
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}