namespace AdventOfCode2023.ColoredCubesGame
{
    internal class MinimumCubeStatistics
    {
        public int Reds { get; set; } = -1;
        public int Greens { get; set; } = -1;
        public int Blues { get; set; } = -1;

        internal void Examine(GameSequence sequence)
        {
            if (Reds < sequence.Reds)
            {
                Reds = sequence.Reds;
            }
            if (Greens < sequence.Greens)
            {
                Greens = sequence.Greens;
            }
            if (Blues < sequence.Blues)
            {
                Blues = sequence.Blues;
            }
        }
    }
}