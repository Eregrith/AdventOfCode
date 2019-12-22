namespace AdventOfCode2019.Mazes
{
    public class MazeKey : MazeCell
    {
        public char Id { get; set; }
        public override char Display => Id;
        public string KeysRequired { get; internal set; }

        public MazeKey(char id, int x, int y)
            : base(x, y)
        {
            Id = id;
        }
    }
}