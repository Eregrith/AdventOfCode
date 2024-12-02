using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.DigitalDisplay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    internal class DayEight
    {
        //378 too low
        public static void PartOne()
        {
            Console.WriteLine("DayEight - Part One");
            List<BrokenDigitalDisplay> lines = PuzzleInputHelper.GetInputLinesStatic("DayEight.txt").Select(l => BrokenDigitalDisplay.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");

            int sum = lines.Sum(l => l.CountEasyDigits());
            
            Console.WriteLine($"There are a total of {sum} easy digits");

            Console.WriteLine("DayEight - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayEight - Part Two");
            List<BrokenDigitalDisplay> lines = PuzzleInputHelper.GetInputLinesStatic("DayEight.txt").Select(l => BrokenDigitalDisplay.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");

            int sum = lines.Sum(l => l.DecryptOutput());

            Console.WriteLine($"There are a total of {sum} digits");

            Console.WriteLine("DayEight - End of part Two");
        }
    }
}
