using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AdventOfCode2020.Days
{
    public class DayOne
    {
        public static void PartOne()
        {
            Console.WriteLine("Day one - Part One");
            List<int> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").Select(l => int.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int prod = lines.SelectMany(a => lines.Select(b => (a+b, a*b)))
                            .Where(sum => sum.Item1 == 2020).First().Item2;
            Console.WriteLine($"Product of lines with sum 2020 is {prod}");
            Console.WriteLine("Day one - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day one - Part Two");
            List<int> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").Select(l => int.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int prod = lines.SelectMany(a => lines.Select(b => (a + b, a * b)))
                            .SelectMany(ab => lines.Select(c => (ab.Item1 + c, ab.Item2 * c)))
                            .Where(sum => sum.Item1 == 2020).First().Item2;
            Console.WriteLine($"Product of lines with sum 2020 is {prod}");
            Console.WriteLine("Day one - End of part Two");
        }
    }
}
