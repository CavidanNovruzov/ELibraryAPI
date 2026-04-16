using ELibraryAPI.Domain.Entities.Common;
using ELibraryAPI.Domain.Entities.Concrete.Auth;

namespace ELibraryAPI.Domain.Entities.Concrete;

public class Order : BaseEntity
{
    public string OrderNumber { get; set; } = null!;

    public Guid UserId { get; set; }
    public AppUser User { get; set; } = null!;

    public Guid OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;

    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = null!;

    public Guid ShippingMethodId { get; set; }
    public ShippingMethod ShippingMethod { get; set; } = null!;

    public decimal TotalAmount { get; set; }
    public string OrderNote { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}