using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.GhostDesert;

namespace AdventOfCode2023.Days
{
    internal class DayEight
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day eight - Part One");
            List<string> input = PuzzleInputHelper.GetInputLines("DayEight.txt");
            DesertMap map = DesertMap.ParseMap(input);

            int steps = map.CountStepsTo("ZZZ");

            Console.WriteLine($"There was {steps} to ZZZ");
            Console.WriteLine("Day eight - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day eight - Part Two");
            List<string> input = PuzzleInputHelper.GetInputLines("DayEight.txt");
            DesertMap map = DesertMap.ParseMap(input);

            int steps = map.CountGhostStepsTo("Z");

            Console.WriteLine($"There was {steps} ghost steps to end in Z");
            Console.WriteLine("Day eight - End of part Two");
        }
    }
}
