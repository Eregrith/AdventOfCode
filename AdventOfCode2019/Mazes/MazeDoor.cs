namespace AdventOfCode2019.Mazes
{
    public class MazeDoor : MazeCell
    {
        public char Id { get; set; }
        public override char Display => Id;

        public char KeyNeeded => Id.ToString().ToLower()[0];

        public MazeDoor(char id, int x, int y)
            : base(x,y)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }
}