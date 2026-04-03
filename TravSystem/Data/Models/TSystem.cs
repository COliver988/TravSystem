namespace TravSystem.Models;

public class TSystem
{
    public int Id { get; set; }

    public int TSubSectorId { get; set; }
    public string Name { get; set; }
    public int PlanetoidBelts { get; set; }
    public int GasGiantCount { get; set; }
    public int PopulationModifier { get; set; }

    public string? BasicNature { get; set; } // Solo, Binary, Trinary

    // Comma-separated list of TStellarType Ids
    public List<int> TStellarTypeIds { get; set; }

    public List<int> StarTypeIds { get; set; }

    public ICollection<TPlanet>? Planets { get; set; }
    public TSubSector? SubSector { get; set; }

    public ICollection<TBase?> Bases { get; set; } = new List<TBase>();
    public ICollection<TSystemTBases>? SystemBases { get; set; }

    public List<TStellarTypes>? StellarTypes { get; set; }
    public List<StarType>? StarTypes { get; set; }
}
