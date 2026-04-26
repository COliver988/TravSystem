using SkiaSharp;
using System;
using System.Collections.Generic;

public class TravellerWorldMapForm8
{
    private const int Triangles = 20;
    private const int HexesPerTriangle = 25;
    private readonly Random _rng = new();

    public record HexCell(int TriangleId, int Q, int R, bool IsWater);

    public List<HexCell> Generate(string uwp)
    {
        int waterDigit = ParseWaterDigit(uwp);
        double waterPercent = waterDigit * 0.1;

        var cells = new List<HexCell>(Triangles * HexesPerTriangle);

        for (int t = 0; t < Triangles; t++)
        {
            foreach (var (q, r) in TriangleHexCoords())
            {
                bool isWater = _rng.NextDouble() < waterPercent;
                cells.Add(new HexCell(t, q, r, isWater));
            }
        }

        Smooth(cells, passes: 3);
        return cells;
    }

    private int ParseWaterDigit(string uwp)
    {
        char c = uwp[2];
        return c switch
        {
            'A' => 10,
            >= '0' and <= '9' => c - '0',
            _ => 0
        };
    }

    private IEnumerable<(int q, int r)> TriangleHexCoords()
    {
        // 5×5 triangular grid (q+r ≤ 4)
        for (int q = 0; q < 5; q++)
            for (int r = 0; r < 5 - q; r++)
                yield return (q, r);
    }

    private void Smooth(List<HexCell> cells, int passes)
    {
        for (int p = 0; p < passes; p++)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int neighbors = CountNeighbors(cells, cells[i]);
                if (neighbors > 3) cells[i] = cells[i] with { IsWater = true };
                else if (neighbors < 2) cells[i] = cells[i] with { IsWater = false };
            }
        }
    }

    private int CountNeighbors(List<HexCell> cells, HexCell cell)
    {
        int count = 0;

        foreach (var n in cells)
        {
            if (n.TriangleId != cell.TriangleId) continue;

            bool adjacent =
                Math.Abs(n.Q - cell.Q) <= 1 &&
                Math.Abs(n.R - cell.R) <= 1;

            if (adjacent && n.IsWater)
                count++;
        }

        return count;
    }

    public SKBitmap Render(List<HexCell> cells, int hexSize = 20)
    {
        int cols = 5;
        int rows = 5;

        int width = Triangles * cols * hexSize;
        int height = rows * hexSize * 2;

        var bmp = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bmp);
        canvas.Clear(SKColors.Black);

        foreach (var cell in cells)
        {
            int baseX = cell.TriangleId * cols * hexSize;

            int x = baseX + cell.Q * hexSize + (cell.R * hexSize / 2);
            int y = (int)(cell.R * hexSize * 0.866);

            var color = cell.IsWater ? SKColors.Blue : SKColors.Green;
            using var paint = new SKPaint { Color = color };

            var pts = HexPoints(x, y, hexSize);
            canvas.DrawPath(pts, paint);
        }

        return bmp;
    }

    private SKPath HexPoints(int x, int y, int size)
    {
        var path = new SKPath();
        for (int i = 0; i < 6; i++)
        {
            double angle = Math.PI / 3 * i + Math.PI / 6;
            float px = x + size * (float)Math.Cos(angle);
            float py = y + size * (float)Math.Sin(angle);

            if (i == 0) path.MoveTo(px, py);
            else path.LineTo(px, py);
        }
        path.Close();
        return path;
    }
}
