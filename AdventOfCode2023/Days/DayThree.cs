using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.GondolaLift;

namespace AdventOfCode2023.Days
{
    internal class DayThree
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day three - Part One");
            char[][] matrix = PuzzleInputHelper.GetInputMatrixStatic("DayThree.txt");
            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            int sum = schematic.Parts.Sum(p => p.Number);

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day three - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day three - Part Two");
            char[][] matrix = PuzzleInputHelper.GetInputMatrixStatic("DayThree.txt");
            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            int sum = schematic.Gears.Sum(p => p.Ratio);

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day three - End of part Two");
        }
    }
}
