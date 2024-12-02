using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Origami;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Days
{
    internal class DayThirteen
    {
        public static void PartOne()
        {
            Console.WriteLine("DayThirteen - Part One");
            List<string>[] lines = PuzzleInputHelper.GetInputLinesBatchedStatic("DayThirteen.txt", "").ToArray();
            Console.WriteLine($"Input has {lines[0].Count} lines");
            OrigamiManual manual = new OrigamiManual(lines[0], lines[1]);

            manual.FoldOnceAndRemoveDuplicates();

            Console.WriteLine($"There are {manual.CountDots} dots visible after one fold");

            Console.WriteLine("DayThirteen - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayThirteen - Part Two");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatchedStatic("DayThirteen.txt", "");
            Console.WriteLine($"Input has {lines.Count} lines");
            OrigamiManual manual = new OrigamiManual(lines[0], lines[1]);

            manual.CompleteAllFolds();
            manual.Display();

            Console.WriteLine("DayThirteen - End of part Two");
        }
    }
}
