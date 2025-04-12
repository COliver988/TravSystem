namespace TravSystem.Models;

public class TPlanet
{
    public int Id { get; set; }
    public int? SubSectorId { get; set; }
    public int? PlanetId { get; set; }
    public int Orbit { get; set; }
    public int StarportID { get; set; }
    public int Size { get; set; }
    public int AtmosphereID { get; set; }
    public int HydrographicsID { get; set; }
    public int Population { get; set; }
    public int GovernmentID { get; set; }
    public int LawLevelID { get; set; }
    public int TechLevelID { get; set; }
}
