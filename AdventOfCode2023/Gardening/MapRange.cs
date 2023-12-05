using AdventOfCode.Elves;

namespace AdventOfCode2023.Gardening;

internal class MapRange
{
    public long DestinationStart { get; set; }
    public long SourceStart { get; set; }
    public long SourceEnd => SourceStart + RangeSize - 1;
    public long RangeSize { get; set; }
    public long Offset => DestinationStart - SourceStart;

    public static MapRange FromLine(string line)
    {
        string[] parts = line.Split(' ');
        return new MapRange
        {
            DestinationStart = long.Parse(parts[0]),
            SourceStart = long.Parse(parts[1]),
            RangeSize = long.Parse(parts[2])
        };
    }

    public bool AppliesTo(long source)
    {
        return source.IsBetween(SourceStart, SourceEnd);
    }

    public long ApplyTo(long source)
    {
        return source + Offset;
    }

    public override string ToString()
    {
        return $"{SourceStart} => {SourceEnd} [{(Offset > 0 ? "+" : "")}{Offset}]";
    }
}