using FlightBooking.Domain.Enums;

namespace FlightBooking.Domain.Entities;

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
    public FlightStatus Status { get; private set; }

    private Flight(){}

    public Flight(
        string flightNumber,
        string origin,
        string destination,
        DateTimeOffset departureTime,
        DateTimeOffset arrivalTime,
        decimal price,
        int totalSeats
    )
    {
        Validate(flightNumber, origin, destination, departureTime, arrivalTime, price, totalSeats);

        Id = Guid.NewGuid();
        FlightNumber = flightNumber;
        Origin = origin;
        Destination = destination;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        Price = price;
        TotalSeats = totalSeats;
        AvailableSeats = totalSeats;
        Status = FlightStatus.Scheduled;
    }

    private void Validate(
        string flightNumber,
        string origin, 
        string destination,
        DateTimeOffset departure,
        DateTimeOffset arrival,
        decimal price,
        int seats)
    {
        if(string.IsNullOrWhiteSpace(origin))
            throw new ArgumentException("The flight must contain a orige.");

        if(string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("The flight must contain a destination.");

        if(departure == default)
            throw new ArgumentException("The flight must have a departure date.");

        if (departure <= DateTimeOffset.UtcNow)
            throw new ArgumentException("Departure must be in the future");

        if(arrival == default)
            throw new ArgumentException("The flight must have an arrival date.");

        if (seats > 1000)
            throw new ArgumentException("Seats exceeds allowed limit");    

        if (price > 100000)
            throw new ArgumentException("Price is unrealistically high");
        
        if(string.IsNullOrWhiteSpace(flightNumber))
            throw new ArgumentException("Flight number is required");

        if(origin.Trim().ToLower() == destination.Trim().ToLower())
            throw new ArgumentException("Origin and destination cannot be the same");

        if(arrival <= departure)
            throw new ArgumentException("Arrival must be after departure");

        if(price <= 0)
            throw new ArgumentException("Price must be greater than zero");

        if(seats <= 0)
            throw new ArgumentException("Seats must be greater than zero");
    }

    public void ReserveSeat(int quantitySeats)
    {
        if(AvailableSeats == 0)
            throw new ArgumentException("Invalid quantity");

        if(Status == FlightStatus.Cancelled)
            throw new InvalidOperationException("Flight is cancelled");
        
        if(quantitySeats > AvailableSeats)
            throw new InvalidOperationException("Not enough seats");

        AvailableSeats -= quantitySeats;
    }

    public void ReleaseSeats(int quantitySeats)
    {
        if(Status == FlightStatus.Cancelled)
            throw new Exception("Cannot reserve seat on cancelled flight");

        if(AvailableSeats + quantitySeats > TotalSeats)
            throw new Exception("Cannot exceed total seats");
        
        AvailableSeats += quantitySeats;
    }

    public bool HasAvailableSeats(int quantitySeats)
    {
        if(Status == FlightStatus.Cancelled)
            throw new Exception("Cancelled flight");

        if(AvailableSeats + quantitySeats > TotalSeats)
            throw new Exception("Cannot exceed total seats");

        if(quantitySeats > AvailableSeats)
            return false;
        
        return true;
    }

    public void CanceldFlight()
    {
        if(Status == FlightStatus.Cancelled)
            throw new Exception("Cancelled flight");

        if(DepartureTime <= DateTimeOffset.Now)
            throw new Exception("The flight has already departed and cannot be cancelled.");

        Status = FlightStatus.Cancelled;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if(Status == FlightStatus.Cancelled)
            throw new Exception("Cancelled flight");

        if(DepartureTime <= DateTimeOffset.Now)
            throw new Exception("The flight has already departed and cannot be cancelled.");

        Price = newPrice;
    }

}
