using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.OASIS;
using AdventOfCode2023.Observatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class DayEleven
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day eleven - Part One");
            char[][] input = PuzzleInputHelper.GetInputMatrix("DayEleven.txt");
            SpaceMap map = SpaceMap.FromInputMatrix(input);

            map.ExpandSpace(1);
            List<int> paths = map.CalculatePaths();
            int sum = paths.Sum();

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day eleven - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day eleven - Part Two");
            char[][] input = PuzzleInputHelper.GetInputMatrix("DayEleven.txt");
            SpaceMap map = SpaceMap.FromInputMatrix(input);

            map.ExpandSpace(999999);
            List<int> paths = map.CalculatePaths();
            BigInteger sum = 0;
            paths.ForEach(p => sum += p);

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day eleven - End of part Two");
        }
    }
}
