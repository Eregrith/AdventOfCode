namespace AdventOfCode2019.Mazes
{
    public class MazeOxygen : MazeCell
    {
        public bool IsActive { get; set; } = true;
        public override char Display => IsActive ? 'O' : 'o';

        public MazeOxygen(int x, int y)
            : base(x, y)
        { }
    }
}