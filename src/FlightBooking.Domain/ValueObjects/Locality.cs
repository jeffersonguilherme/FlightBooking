namespace FlightBooking.Domain.ValueObjects;

public sealed record Locality
{
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string Country { get; private set; } = null!;

    private Locality() { }

    private Locality(
        string city,
        string state,
        string country)
    {
        City = city;
        State = state;
        Country = country;
    }

    public static Locality Create(
        string city,
        string state,
        string country)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.", nameof(city));

        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State is required.", nameof(state));

        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required.", nameof(country));

        return new Locality(
            city.Trim(),
            state.Trim(),
            country.Trim());
    }
}