using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.ColoredCubesGame;

namespace AdventOfCode2023.Days
{
    internal static class DayTwo
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day two - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTwo.txt").ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            CubeLimits limits = new CubeLimits
            {
                Red = 12,
                Green = 13,
                Blue = 14,
            };

            List<GameLine> games = lines.Select(GameLine.ToGameLine).ToList();
            int sum = games.Where(g => g.IsValid(limits)).Sum(g => g.Id);

            Console.WriteLine($"Sum is : {sum}");
            Console.WriteLine("Day two - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day two - Part Two");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTwo.txt").ToList();
            Console.WriteLine($"Input has {lines.Count} lines");

            List<GameLine> games = lines.Select(GameLine.ToGameLine).ToList();
            int sum = games.Sum(g => g.Power);

            Console.WriteLine($"Sum is : {sum}");
            Console.WriteLine("Day two - End of part Two");
        }

    }
}
