using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Caverns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdventOfCode2021.Days
{
    internal class DayEleven
    {
        public static void PartOne()
        {
            Console.WriteLine("DayEleven - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayEleven.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            DumboOctopusCavern cavern = new DumboOctopusCavern(lines);
            int steps = 100;

            for (int i = 0; i  < steps; i++)
            {
                Console.SetCursorPosition(0, 2);
                cavern.Display();
                cavern.Step();
                //Console.ReadLine();
            }

            Console.SetCursorPosition(0, 2);
            cavern.Display();

            Console.WriteLine($"There has been a total of {cavern.CountTotalFlashes()} total flashes after {steps} steps");

            Console.WriteLine("DayEleven - End of part One");
        }

        //454057517 too low
        public static void PartTwo()
        {
            Console.WriteLine("DayEleven - Part Two");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayEleven.txt");
            Console.WriteLine($"Input has {lines.Count} lines");

            DumboOctopusCavern cavern = new DumboOctopusCavern(lines);
            int steps = 0;

            while (!cavern.DidAllOctopusFlashedThisStep())
            {
                cavern.Step();
                steps++;
            }

            Console.WriteLine($"There has been a complete flash after {steps} steps");


            Console.WriteLine("DayEleven - End of part Two");
        }
    }
}
