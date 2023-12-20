namespace AdventOfCode2023.PipeLoops;

internal class TileElement
{
    public int X { get; }
    public int Y { get; }
    public char Type { get; }
    public int? Distance { get; internal set; }

    public TileElement(int x, int y, char type)
    {
        Type = type;
        X = x;
        Y = y;
    }
}