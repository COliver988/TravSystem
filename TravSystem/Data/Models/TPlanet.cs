using System.ComponentModel.DataAnnotations;
namespace TravSystem.Models;

public class TPlanet
{
    private static string hexcodes = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? TSubSectorId { get; set; }
    public int? TSystemId { get; set; }
    public int? TPlanetId { get; set; }
    public int Orbit { get; set; }
    public int TStarportId { get; set; }
    public int Size { get; set; }
    public int TAtmosphereId { get; set; }
    public int Hydrographics { get; set; }

    public int Population { get; set; }
    public int TGovernmentId { get; set; }
    public int TLawLevelId { get; set; }

    public int TechLevel { get; set; }

    public int? TravelCodeId { get; set; }

    public string UWP => $"{this.Starport?.HexCode}{this.Size}{this.Atmosphere?.HexCode}{this.Hydrographics}{this.Population}{this.Government?.HexCode}{this.LawLevel?.HexCode}-{hexcodes.Substring(TechLevel, 1)[0]}";
    public TStarport? Starport { get; set; }
    public TAtmosphere? Atmosphere { get; set; }
    public TGovernment? Government { get; set; }
    public TLawLevel? LawLevel { get; set; }

    public TSubSector? SubSector { get; set; }
    public TTravelCode? TravelCode { get; set; }
    public TSystem? System { get; set; }

}
