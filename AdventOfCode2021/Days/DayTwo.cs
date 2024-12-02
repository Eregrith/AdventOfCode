using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Submarine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Days
{
    public static class DayTwo
    {
        public static void PartOne()
        {
            Console.WriteLine("Day two - Part One");
            SubCommandFactory factory = new SubCommandFactory();
            List<SubCommand> lines = PuzzleInputHelper.GetInputLinesStatic("DayTwo.txt").Select(l => factory.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            ControlledSubmarine sub = new ControlledSubmarine();

            lines.ForEach(l => sub.ApplyCommand(l));

            Console.WriteLine($"Final depth is {sub.Depth}, final horizontal pos is {sub.HorizontalPosition}");
            Console.WriteLine($"Product is {sub.Depth * sub.HorizontalPosition}");
            Console.WriteLine("Day two - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day two - Part Twp");
            SubCommandFactory factory = new SubCommandFactory();
            List<SubCommand> lines = PuzzleInputHelper.GetInputLinesStatic("DayTwo.txt").Select(l => factory.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            AimableControlledSubmarine sub = new AimableControlledSubmarine();

            lines.ForEach(l => sub.ApplyCommand(l));

            Console.WriteLine($"Final depth is {sub.Depth}, final horizontal pos is {sub.HorizontalPosition}");
            Console.WriteLine($"Product is {sub.Depth * sub.HorizontalPosition}");
            Console.WriteLine("Day two - End of part Two");
        }
    }
}
