using FlighBooking.Domain.Enums;

namespace FlighBooking.Domain.Entities;

public class Cart
{
    public Guid Id { get; private set; }
    public string UserId { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public OrderStatus Status { get; private set; } = OrderStatus.Open;
    public ICollection<CartItem> Items { get; private set; } =new List<CartItem>();
}