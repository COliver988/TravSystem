namespace TravSystem.Models;

public class TStellarZones
{
    public int Id { get; set; }
    // the Ia, Ib stuff
    public int TStellarTypeId { get; set; }

    // e.g. "B0", "A5", "M3", etc
    public string StarType { get; set; } = string.Empty; // e.g. "B", "A", "M", etc
    public int InnerZoneLow { get; set; }
    public int InnerZoneHigh { get; set; }
    public int HabitableZone { get; set; }

    public TStellarTypes? TStellarType { get; set; } // Navigation property to TStellarTypes
}
