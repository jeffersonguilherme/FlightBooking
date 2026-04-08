using FlightBooking.Application.DTOs.Flight;
using FlightBooking.Domain.Response;
using MediatR;

namespace FlightBooking.Application.Features.Commands.CreateFlight;

public record CreateFlightCommand(FlightCreateDto Dto) : IRequest<ResponseModel<FlightResponseDto>>;