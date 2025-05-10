namespace TravSystem.Models;

public class TradeClassification
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string? Size { get; set; }
    public string? Atmo { get; set; }
    public string? Hydro { get; set; }
    public string? Population { get; set; }
    public string? Government { get; set; }
    public string? LawLevel { get; set; }
    public string? TechLevel { get; set; }
}
