using SkiaSharp;
using TravSystem.Models;

namespace TravSystem.Services;

public interface ITravellerWorldMapForm8
{
    public List<HexCell> Generate(string uwp, string worldName);
    public SKBitmap Render(List<HexCell> cells, string uwp);
}
