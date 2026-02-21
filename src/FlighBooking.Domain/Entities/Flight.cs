using FlighBooking.Domain.Enums;

namespace FlighBooking.Domain.Entities;

public class Flight
{
    public Guid Id { get; private set; }
    public string FlightNumber { get; private set; } = string.Empty;
    public string Origin { get; private set; } = string.Empty;
    public string Destination { get; private set; } = string.Empty;
    public DateTimeOffset DepartureTime { get; private set; }
    public DateTimeOffset ArrivalTime { get; private set; }
    public decimal Price { get; private set; }
    public int TotalSeats { get; private set; }
    public int AvailableSeats { get; private set; }
    public OrderStatus Status { get; private set; }
}
