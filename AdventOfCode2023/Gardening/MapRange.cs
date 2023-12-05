using AdventOfCode.Elves;

namespace AdventOfCode2023.Gardening;

internal class MapRange
{
    public int SourceStart { get; set; }
    public int DestinationStart { get; set; }
    public int RangeSize { get; set; }

    public static MapRange FromLine(string line)
    {
        string[] parts = line.Split(' ');
        return new MapRange
        {
            SourceStart = int.Parse(parts[0]),
            DestinationStart = int.Parse(parts[1]),
            RangeSize = int.Parse(parts[2])
        };
    }

    public bool AppliesTo(int source)
    {
        return source.IsBetween(SourceStart, SourceStart + RangeSize - 1);
    }

    public int ApplyTo(int source)
    {
        return source + (DestinationStart - SourceStart);
    }
}