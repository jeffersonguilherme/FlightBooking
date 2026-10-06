using FlightBooking.Application.Common.Errors;
using FlightBooking.Application.Common.Results;
using FlightBooking.Application.DTOs.Flight;
using FlightBooking.Domain.Entities;
using FlightBooking.Domain.Repositories;
using MediatR;

namespace FlightBooking.Application.Features.Commands.CreateFlight;

public class CreateFlightHandler : IRequestHandler<CreateFlightCommand, Result<FlightResponseDto>>
{
    private readonly IFlightRepository _repository;

    public CreateFlightHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<FlightResponseDto>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingFlight = await _repository.GetByFlightNumberAsync(dto.FlightNumber, cancellationToken);

        if(existingFlight is not null)
        {
            return Result<FlightResponseDto>.Fail(Failure.Conflict("A flight with this number already exists."));
        }

        var flight = Flight.Create(
            dto.FlightNumber,
            dto.Origin,
            dto.Destination,
            dto.DepartureTime,
            dto.ArrivalTime,
            dto.Price,
            dto.TotalSeats
        );

        await _repository.AddAsync(flight, cancellationToken);

        var response = new FlightResponseDto(
            flight.Id,
            flight.FlightNumber,
            flight.Origin,
            flight.Destination,
            flight.DepartureTime,
            flight.ArrivalTime,
            dto.Price,
            flight.TotalSeats,
            flight.AvailableSeats,
            flight.Status
        );

        return Result<FlightResponseDto>.Success(response);
        
    }
}