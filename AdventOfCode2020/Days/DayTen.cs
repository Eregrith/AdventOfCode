using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class DayTen
    {
        public static void PartOne()
        {
            Console.WriteLine("Day Ten - Part One");
            List<int> adapters = PuzzleInputHelper.GetInputLines("DayTen.txt")
                .Select(Int32.Parse).OrderBy(i => i).ToList();

            Console.WriteLine($"There are {adapters.Count} adapters");

            Console.WriteLine("Adapters in order:");
            Console.WriteLine(String.Join(", ", adapters));

            int oneDiff = 1;
            int threeDiff = 1;
            for (int i = 0; i < adapters.Count; i++)
            {
                if (i > 0)
                {
                    if (adapters[i] - adapters[i - 1] == 1) oneDiff++;
                    else if (adapters[i] - adapters[i - 1] == 3) threeDiff++;
                }
            }
            Console.WriteLine("Product of 1-differences and 3-differences: " + oneDiff * threeDiff);

            Console.WriteLine("Day Ten - End of Part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day Ten - Part Two");

            Console.WriteLine("Day Ten - End of Part Two");
        }
    }
}
