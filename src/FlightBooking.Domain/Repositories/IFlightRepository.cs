using FlightBooking.Domain.Entities;

namespace FlightBooking.Domain.Repositories;

public interface IFlightRepository
{
    Task AddAsync(Flight flight, CancellationToken cancellationToken);
    Task<Flight?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Flight> GetByFlightNumberAsync(string FlightNumber, CancellationToken cancellationToken);
    Task<IEnumerable<Flight>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task UpdateAsync(Flight flight, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}