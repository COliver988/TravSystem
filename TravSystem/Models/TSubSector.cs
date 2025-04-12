namespace TravSystem.Models;

public class TSubSector
{
    public int Id { get; set; }
    int position { get; set; }
    public string Name { get; set; }

    IEnumerable<TSystem> Systems { get; set; }
}
