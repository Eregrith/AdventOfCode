namespace AdventOfCode2023.PipeLoops;

internal class Ground : TileElement
{
    public Ground(int x, int y)
        : base(x, y, '.')
    {
        Position = '?';
    }

    public char Position { get; set; }
}