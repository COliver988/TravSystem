namespace TravSystem.Models;

public class TSystemFeature
{
    public enum NumberOfStars
    {
        Solo,
        Binary,
        Trinary
    };

    public enum Orbits
    {
        Close,
        One,
        Two,
        Three,
        FourPlusRoll,
        FivePlusRoll,
        SixPLusRoll,
        SevenPlusRoll,
        EightPlusRoll,
        Far
    }

    public int Id { get; set; }

    // 0-12 -> die roll
    public int Roll { get; set; }

    public NumberOfStars BasicNature { get; set; }

    // BAMKGF -> see stellar types? 
    public string PrimaryType { get; set; } = string.Empty;
    public string PrimarySize { get; set; } = string.Empty;
    public string CompanionType { get; set; } = string.Empty;
    public string CompanionSize { get; set; } = string.Empty;

    // note: will translate enum to string for storage; Close, Far, else 1, 2, 3, etc
    public string CompanionOrbit { get; set; } = string.Empty;
    public int MaxOrbits { get; set; }
    public bool GasGiantPresent { get; set; }
    public int GasGiantQty { get; set; }
    public bool BeltPresent { get; set; }
    public int BeltQty { get; set; }
}
