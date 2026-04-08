using FlightBooking.Application.DTOs.Flight;
using FlightBooking.Domain.Entities;
using FlightBooking.Domain.Repositories;
using FlightBooking.Domain.Response;
using MediatR;

namespace FlightBooking.Application.Features.Commands.CreateFlight;

public class CreateFlightHandler : IRequestHandler<CreateFlightCommand, ResponseModel<FlightResponseDto>>
{
    private readonly IFlightRepository _repository;

    public CreateFlightHandler(IFlightRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseModel<FlightResponseDto>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var flight = new Flight(
            dto.FlightNumber,
            dto.Origin,
            dto.Destination,
            dto.DepartureTime,
            dto.ArrivalTime,
            dto.Price,
            dto.TotalSeats
        );

        await _repository.AddAsync(flight);

        return new ResponseModel<FlightResponseDto>
        {
            Status = true,
            Message = "Voo criado com sucesso.",
            Data = new FlightResponseDto(
                flight.Id,
                flight.FlightNumber,
                flight.Origin,
                flight.Destination,
                flight.DepartureTime,
                flight.ArrivalTime,
                flight.Price,
                flight.TotalSeats,
                flight.AvailableSeats,
                flight.Status
            )
        };
    }
}