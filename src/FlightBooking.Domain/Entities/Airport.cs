using FlightBooking.Domain.ValueObjects;

namespace FlightBooking.Domain.Entities;

public class Airport
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Acronym { get; private set; } = string.Empty;
    public Locality Locality { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Airport(){}

    public static Airport Create(
        string name,
        string acronym,
        Locality locality 
    )
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The airport must have a valid name.");
        if(acronym.Length != 3) throw new ArgumentException("The acronym must have a maximum of 3 characters.");
        if(locality is null) throw new ArgumentException("The location must be a valid location.");

        var airport = new Airport
        {
            Id = Guid.NewGuid(),
            Name = name,
            Acronym = acronym,
            Locality = locality,
            CreatedAt = DateTime.UtcNow
        };
        return airport;
    }

    public void UpdateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The airport must have a valid name.", nameof(name));
        
        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateAcronym(string acronym)
    {
        if(acronym.Length != 3) throw new ArgumentException("The acronym must have a maximum of 3 characters.");
        
        Acronym = acronym;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateLocality(Locality locality)
    {
        if(locality is null) throw new ArgumentException("The location must be a valid location.");
        
        Locality = locality;
        UpdatedAt = DateTime.UtcNow;
    }
}