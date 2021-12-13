using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    internal class DaySeven
    {
        public static void PartOne()
        {
            Console.WriteLine("DaySeven - Part One");
            List<int> lines = PuzzleInputHelper.GetInputLines("DaySeven.txt").SelectMany(l => l.Split(",")).Select(l => int.Parse(l)).ToList();
            lines.Sort();
            Console.WriteLine($"Input has {lines.Count} crabs");

            int median = lines.ElementAt(lines.Count / 2);

            Console.WriteLine($"The median position is {median}");

            int totalDistanceFromMedian = lines.Aggregate(0, (agg, l) => agg + Math.Abs(median - l));

            Console.WriteLine($"Sum of distances to median is {totalDistanceFromMedian}");

            Console.WriteLine("DaySeven - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DaySeven - Part Two");
            List<int> lines = PuzzleInputHelper.GetInputLines("DaySeven.txt").SelectMany(l => l.Split(",")).Select(l => int.Parse(l)).ToList();
            lines.Sort();
            Console.WriteLine($"Input has {lines.Count} crabs");

            int avg = 471;

            Console.WriteLine($"The avg position is {avg}");

            int totalDistanceFromAvg = lines.Aggregate(0, (agg, l) => GetDistanceToAvg(agg, l, avg));

            Console.WriteLine($"Sum of distances to avg is {totalDistanceFromAvg}");

            Console.WriteLine("DaySeven - End of part Two");
        }

        private static int GetDistanceToAvg(int agg, int l, int avg)
        {
            int dist = SumOfOneToN(Math.Abs(avg - l));
            return agg + dist;
        }

        private static int SumOfOneToN(int n)
        {
            return n + ((n - 1) * n) / 2;
        }
    }
}
