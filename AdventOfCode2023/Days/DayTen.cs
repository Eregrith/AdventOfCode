using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.PipeLoops;

namespace AdventOfCode2023.Days
{
    internal class DayTen
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day ten - Part One");
            char[][] input = PuzzleInputHelper.GetInputMatrixStatic("DayTen.txt");

            PipeLoopMatrix matrix = PipeLoopMatrix.FromInput(input);

            Console.WriteLine($"Furthest distance is {matrix.FurthestDistance}");
            Console.WriteLine("Day ten - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day ten - Part Two");
            List<string> input = PuzzleInputHelper.GetInputLinesStatic("DayTen.txt");

            Console.WriteLine("Day ten - End of part Two");
        }
    }
}
