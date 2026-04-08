using FlightBooking.Domain.Entities;

namespace FlightBooking.Domain.Repositories;

public interface IFlightRepository
{
    Task AddAsync(Flight flight);
    Task<Flight?> GetByIdAsync(Guid id);
    Task<IEnumerable<Flight>> GetAllAsync(int pageNumber, int pageSize);
    Task UpdateAsync(Flight flight);
    Task DeleteAsync(Guid id);
}