using FlightBooking.Application.Common.Results;
using FlightBooking.Application.DTOs.Flight;
using MediatR;

namespace FlightBooking.Application.Features.Commands.CreateFlight;

public record CreateFlightCommand(FlightCreateDto Dto) : IRequest<Result<FlightResponseDto>>;