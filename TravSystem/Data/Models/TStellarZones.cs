namespace TravSystem.Models;

public class TStellarZones
{
    public int Id { get; set; }
    // the Ia, Ib stuff
    public int TStellarTypeId { get; set; }

    // e.g. "B0", "A5", "M3", etc
    public int StarTypeId { get; set; }
    public int InnerZoneLow { get; set; }
    public int InnerZoneHigh { get; set; }
    public int HabitableZone { get; set; }

    public TStellarTypes? TStellarType { get; set; } // Navigation property to TStellarTypes
    public StarType? StarType { get; set; } // Navigation property to StarType
}
