using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Days
{
    public static class DayOne
    {
        public static void PartOne()
        {
            Console.WriteLine("Day one - Part One");
            List<int> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").Select(l => int.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int increases = 0;
            for (int i = 1; i < lines.Count; i++)
            {
                if (SumFromSize(lines, i, 1) > SumFromSize(lines, i - 1, 1))
                    increases++;
            }
            Console.WriteLine($"Lines increased {increases} times");
            Console.WriteLine("Day one - End of part One");
        }

        private static int SumFromSize(List<int> l, int from, int size)
        {
            int sum = 0;
            while (size > 0)
            {
                sum += l[from++];
                size--;
            }
            return sum;
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day one - Part Two");
            List<int> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").Select(l => int.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int increases = 0;
            for (int i = 1; i < lines.Count - 2; i++)
            {
                if (SumFromSize(lines, i, 3) > SumFromSize(lines, i - 1, 3))
                    increases++;
            }
            Console.WriteLine($"Lines increased {increases} times");
            Console.WriteLine("Day one - End of part One");
        }
    }
}
