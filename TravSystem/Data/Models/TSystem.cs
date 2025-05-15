namespace TravSystem.Models;

public class TSystem
{
    public int Id { get; set; }
    public int SubSectorId { get; set; }
    public string Name { get; set; }
    public int PlanetoidBelts { get; set; }
    public int GasGiantCount { get; set; }
    public int PopulationModifier { get; set; }

    IEnumerable<TPlanet> Planets { get; set; }
    public TSubSector? SubSector { get; set; }

    public List<int> SelectedBaseIds { get; set; } = new List<int>();
    public ICollection<TBase> Bases { get; set; }
    public ICollection<TSystemTBases> SystemBases { get; set; }
}
