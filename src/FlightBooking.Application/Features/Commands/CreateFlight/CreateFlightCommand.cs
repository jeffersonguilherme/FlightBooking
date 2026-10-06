using FlightBooking.Application.DTOs.Flight;
using FlightBooking.Application.Response;

using MediatR;

namespace FlightBooking.Application.Features.Commands.CreateFlight;

public record CreateFlightCommand(FlightCreateDto Dto) : IRequest<Result<FlightResponseDto>>;