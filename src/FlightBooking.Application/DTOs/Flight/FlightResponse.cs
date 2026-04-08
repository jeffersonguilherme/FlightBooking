using FlightBooking.Domain.Enums;

namespace FlightBooking.Application.DTOs.Flight;

public record FlightResponseDto
(
    Guid Id,
    string FlightNumber,
    string Origin, 
    string Destination,
    DateTimeOffset DepartureTime,
    DateTimeOffset ArrivalTime, 
    decimal Price, 
    int TotalSeats, 
    int AvailableSeats, 
    FlightStatus Status 

);