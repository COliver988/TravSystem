using SkiaSharp;
using TravSystem.Models;

namespace TravSystem.Services;

public class TravellerWorldMapForm8 : ITravellerWorldMapForm8
{
    private const int Triangles = 20;
    private const int HexesPerTriangle = 25; // 5x5 grid
    private readonly Random _rng = new();

    // Drawing Constants to match the Form 8 layout
    private const float Padding = 40f;
    private const float HeaderHeight = 100f;
    private const float FooterHeight = 60f;
    private string _worldName = string.Empty;

    public List<HexCell> Generate(string uwp, string worldName)
    {
        _worldName = worldName;
        int waterDigit = ParseWaterDigit(uwp);
        double waterPercent = waterDigit * 0.1;

        var cells = new List<HexCell>();

        for (int t = 0; t < Triangles; t++)
        {
            foreach (var (q, r) in TriangleHexCoords())
            {
                // Simple noise-based water gen
                bool isWater = _rng.NextDouble() < waterPercent;
                cells.Add(new HexCell(t, q, r, isWater));
            }
        }
        return cells;
    }

    private int ParseWaterDigit(string uwp) => (uwp.Length >= 3 && char.IsDigit(uwp[2])) ? uwp[2] - '0' : 0;

    private IEnumerable<(int q, int r)> TriangleHexCoords()
    {
        for (int q = 0; q < 5; q++)
            for (int r = 0; r < 5 - q; r++)
                yield return (q, r);
    }

    public SKBitmap Render(List<HexCell> cells, string uwp = "X000000-0")
    {
        // Calculate canvas size (roughly 1200x900 for a clear Form 8 look)
        int width = 1200;
        int height = 940;
        var bmp = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bmp);
        canvas.Clear(SKColors.White);

        DrawFormUI(canvas, width, height, _worldName, uwp);

        // Scaling factors for the icosahedral layout
        // The image has 5.5 triangle-widths across
        float triWidth = (width - (Padding * 2)) / 5.5f;
        float triHeight = triWidth * 0.866f;
        float hexSize = triWidth / 6.5f;

        foreach (var cell in cells)
        {
            var (baseX, baseY, isFlipped) = GetTriangleOffset(cell.TriangleId, triWidth, triHeight);

            // Offset for centering within the padding and header
            baseX += Padding + (triWidth / 2);
            baseY += Padding + HeaderHeight;

            // Calculate Hex position within the triangle
            // This maps the 5x5 hex grid to the triangular face
            float x, y;
            if (!isFlipped)
            {
                x = baseX + (cell.Q - cell.R) * (hexSize * 0.866f);
                y = baseY + (cell.Q + cell.R) * (hexSize * 0.75f);
            }
            else
            {
                x = baseX + (cell.R - cell.Q) * (hexSize * 0.866f);
                y = baseY - (cell.Q + cell.R) * (hexSize * 0.75f) + triHeight;
            }

            DrawHex(canvas, x, y, hexSize * 0.6f, cell.IsWater);
        }

        return bmp;
    }

    private void DrawFormUI(SKCanvas canvas, int w, int h, string name, string uwp)
    {
        using var paint = new SKPaint { Color = SKColors.Black, Style = SKPaintStyle.Stroke, StrokeWidth = 2 };
        using var textPaint = new SKPaint { Color = SKColors.Black, TextSize = 24, IsAntialias = true };

        // Outer border
        canvas.DrawRect(10, 10, w - 20, h - 20, paint);

        // Header Section
        canvas.DrawLine(10, HeaderHeight, w - 10, HeaderHeight, paint);
        canvas.DrawText("World Map Grid", 30, 50, new SKPaint { TextSize = 32, FakeBoldText = true });
        canvas.DrawText($"World Name: {name} ({uwp})", 30, 85, textPaint);

        // Footer Section
        canvas.DrawLine(10, h - FooterHeight, w - 10, h - FooterHeight, paint);
        canvas.DrawText("IS Map Form 8", 30, h - 25, textPaint);
    }

    private (float x, float y, bool flipped) GetTriangleOffset(int id, float tw, float th)
    {
        // 0-4: North Row (Down-pointing)
        if (id < 5) return (id * tw, 0, false);

        // 5-14: Equator Row (Alternating)
        if (id < 15)
        {
            int idx = id - 5;
            bool flip = idx % 2 != 0;
            return ((idx * 0.5f) * tw, th, flip);
        }

        // 15-19: South Row (Up-pointing)
        int sIdx = id - 15;
        return ((sIdx + 0.5f) * tw, th * 2, true);
    }

    private void DrawHex(SKCanvas canvas, float x, float y, float size, bool isWater)
    {
        using var fill = new SKPaint { Color = isWater ? SKColors.LightBlue : SKColors.LightGray, Style = SKPaintStyle.Fill };
        using var border = new SKPaint { Color = SKColors.DarkGray, Style = SKPaintStyle.Stroke, StrokeWidth = 1 };

        var path = new SKPath();
        for (int i = 0; i < 6; i++)
        {
            float angle = (float)(Math.PI / 3 * i);
            float px = x + size * (float)Math.Cos(angle);
            float py = y + size * (float)Math.Sin(angle);
            if (i == 0) path.MoveTo(px, py); else path.LineTo(px, py);
        }
        path.Close();

        canvas.DrawPath(path, fill);
        canvas.DrawPath(path, border);
    }
}