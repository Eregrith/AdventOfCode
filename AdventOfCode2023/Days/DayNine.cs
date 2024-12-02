using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.OASIS;

namespace AdventOfCode2023.Days
{
    internal class DayNine
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day nine - Part One");
            List<string> input = PuzzleInputHelper.GetInputLinesStatic("DayNine.txt");
            List<OasisHistoryReport> reports = input.Select(OasisHistoryReport.FromInput).ToList();

            int sum = reports.Sum(r => r.NextValue);

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day nine - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day nine - Part Two");
            List<string> input = PuzzleInputHelper.GetInputLinesStatic("DayNine.txt");
            List<OasisHistoryReport> reports = input.Select(OasisHistoryReport.FromInput).ToList();

            int sum = reports.Sum(r => r.PreviousValue);

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day nine - End of part Two");
        }
    }
}
