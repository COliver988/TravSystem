using SkiaSharp;
using System;
using System.Collections.Generic;

public class TravellerWorldMap
{
    private const int HexCount = 500;
    private readonly Random _rng = new();

    public record HexCell(int Id, bool IsWater);

    public List<HexCell> Generate(string uwp)
    {
        int waterDigit = ParseWaterDigit(uwp);
        double waterPercent = waterDigit * 0.1;

        var cells = new List<HexCell>(HexCount);
        for (int i = 0; i < HexCount; i++)
        {
            bool isWater = _rng.NextDouble() < waterPercent;
            cells.Add(new HexCell(i, isWater));
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

    private void Smooth(List<HexCell> cells, int passes)
    {
        for (int p = 0; p < passes; p++)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                int neighbors = CountNeighbors(cells, i);
                if (neighbors > 3) cells[i] = cells[i] with { IsWater = true };
                else if (neighbors < 2) cells[i] = cells[i] with { IsWater = false };
            }
        }
    }

    private int CountNeighbors(List<HexCell> cells, int index)
    {
        int count = 0;
        for (int offset = -1; offset <= 1; offset++)
        {
            int n = index + offset;
            if (n >= 0 && n < cells.Count && cells[n].IsWater)
                count++;
        }
        return count;
    }

    public SKBitmap Render(List<HexCell> cells, int hexSize = 20)
    {
        int cols = 25;
        int rows = 20;

        var bmp = new SKBitmap(cols * hexSize, rows * hexSize);
        using var canvas = new SKCanvas(bmp);
        canvas.Clear(SKColors.Black);

        foreach (var cell in cells)
        {
            int x = (cell.Id % cols) * hexSize;
            int y = (cell.Id / cols) * hexSize;

            var color = cell.IsWater ? SKColors.Blue : SKColors.Green;
            using var paint = new SKPaint { Color = color };

            canvas.DrawCircle(x + hexSize / 2, y + hexSize / 2, hexSize / 2 - 2, paint);
        }

        return bmp;
    }
}
