namespace TravSystem.Models;

public class TSystem
{
    public int Id { get; set; }
    public int SubSectorId { get; set; }
    public string Name { get; set; }

    IEnumerable<TPlanet> Planets { get; set; }
    public TSubSector? SubSector { get; set; }
}
