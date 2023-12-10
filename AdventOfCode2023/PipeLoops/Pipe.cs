namespace AdventOfCode2023.PipeLoops
{
    internal class Pipe
    {
        public int? Distance { get; internal set; }
        public char Type { get; }
        public bool HasRightConnector => Type == 'S' || Type == '-' || Type == 'F' || Type == 'L';
        public bool HasLeftConnector => Type == 'S' || Type == '-' || Type == '7' || Type == 'J';
        public bool HasTopConnector => Type == 'S' || Type == '|' || Type == 'L' || Type == 'J';
        public bool HasBottomConnector => Type == 'S' || Type == '|' || Type == 'F' || Type == '7';
        public int X { get; }
        public int Y { get; }

        public Pipe(int x, int y, char type)
        {
            Type = type;
            X = x;
            Y = y;
        }

        internal bool ConnectsTo(Pipe pipe)
        {
            if (HasRightConnector
                && pipe.HasLeftConnector
                && pipe.Y == Y
                && pipe.X == X + 1)
                return true;

            if (HasBottomConnector
                && pipe.HasTopConnector
                && pipe.Y == Y + 1
                && pipe.X == X)
                return true;

            if (HasLeftConnector
                && pipe.HasRightConnector
                && pipe.Y == Y
                && pipe.X == X - 1)
                return true;

            if (HasTopConnector
                && pipe.HasBottomConnector
                && pipe.Y == Y - 1
                && pipe.X == X)
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"{Type} (x:{X}, y:{Y})";
        }
    }
}