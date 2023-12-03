namespace AdventOfCode2023.ColoredCubesGame
{
    public class GameSequence
    {
        public int Reds { get; set; }
        public int Greens { get; set; }
        public int Blues { get; set; }

        internal bool IsValid(CubeLimits limits)
        {
            return Reds <= limits.Red
                && Greens <= limits.Green
                && Blues <= limits.Blue;
        }
    }
}