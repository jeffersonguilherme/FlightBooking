namespace FlightBooking.Application.DTOs.Flight;

public class FlightUpdateDto
{
    public string FlightNumber { get;  set; } = string.Empty;
    public string Origin { get;  set; } = string.Empty;
    public string Destination { get;  set; } = string.Empty;
    public DateTimeOffset DepartureTime { get;  set; }
    public DateTimeOffset ArrivalTime { get;  set; }
    public decimal Price { get;  set; }
    public int TotalSeats { get;  set; }

}