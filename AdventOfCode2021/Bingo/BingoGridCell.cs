namespace AdventOfCode2021.Bingo
{
    internal class BingoGridCell
    {
        public int Value { get; set; }
        public bool Marked = false;
        public int X;
        public int Y;

        public BingoGridCell(int y, int x)
        {
            Y = y;
            X = x;
        }
    }
}