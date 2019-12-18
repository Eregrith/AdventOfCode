namespace AdventOfCode2019.Mazes
{
    internal class MazeOxygen : MazeCell
    {
        public bool IsActive { get; set; } = true;

        public MazeOxygen(int x, int y)
            : base(x, y)
        { }
    }
}