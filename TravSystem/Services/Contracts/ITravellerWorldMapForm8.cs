using SkiaSharp;
using TravSystem.Models;

namespace TravSystem.Services;

public interface ITravellerWorldMapForm8
{
    public List<HexCell> Generate(string uwp);
    public SKBitmap Render(List<HexCell> cells, int hexSize);
}
