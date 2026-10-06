namespace FlightBooking.Domain.Entities;

public class Airport
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Acronym { get; private set; } = string.Empty;
    public int MyProperty { get; private set; }
}