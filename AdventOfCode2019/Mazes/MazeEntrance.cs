namespace AdventOfCode2019.Mazes
{
    public class MazeEntrance : MazeCell
    {
        public override char Display => '@';

        public MazeEntrance(int x, int y)
            : base(x, y)
        {
        }
    }
}