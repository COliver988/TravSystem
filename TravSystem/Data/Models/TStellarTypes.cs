namespace TravSystem.Models;

public class TStellarTypes
{
    public int Id { get; set; }

    // Supergirant, amin sequence, etc
    public string Type { get; set; }

    // i1, 1b, II, etc
    public string Size { get; set; }

    public string CompanionType { get; set; } = string.Empty; // e.g. "B", "M", "K", etc
    public string CompanionSize { get; set; } = string.Empty; // e.g. "I", "II", "III", etc
    public string CompanionOrbit { get; set; } = string.Empty; // e.g. "Close", "1", "2", "3", etc

    public List<TStellarZones> StellarZones { get; set; } = new List<TStellarZones>();
}
