using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Days
{
    internal class DayNine
    {
        //46401 too high
        public static void PartOne()
        {
            Console.WriteLine("DayNine - Part One");
            char[][] soil = PuzzleInputHelper.GetInputMatrixStatic("DayNine.txt");
            Console.WriteLine($"Input is a matrix of {soil[0].Length} width and {soil.Length} height");
            int[][] convertedSoil = soil.Select(line => line.Select(c => int.Parse(c + "")).ToArray()).ToArray();
            LavaTubes tubeSystem = new LavaTubes(convertedSoil);

            Console.WriteLine($"The sum is {tubeSystem.GetLowPointsRiskLevelSum()} risk");

            Console.WriteLine("DayNine - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayNine - Part Two");
            char[][] soil = PuzzleInputHelper.GetInputMatrixStatic("DayNine.txt");
            Console.WriteLine($"Input is a matrix of {soil[0].Length} width and {soil.Length} height");
            int[][] convertedSoil = soil.Select(line => line.Select(c => int.Parse(c + "")).ToArray()).ToArray();
            LavaTubes tubeSystem = new LavaTubes(convertedSoil);

            Console.WriteLine($"The product of all basin sizes is {tubeSystem.GetProductOfBasinSizes()}");

            Console.WriteLine("DayNine - End of part Two");
        }
    }
}
