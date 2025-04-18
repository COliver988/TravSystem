using System.ComponentModel.DataAnnotations;

namespace TravSystem.Models;

public class TAtmosphere
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [StringLength(1, ErrorMessage = "The field must be a single character.")]
    public string HexCode { get; set; }
}
