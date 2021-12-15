using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Caverns;
using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Days
{
    internal class DayTwelve
    {
        public static void PartOne()
        {
            Console.WriteLine("DayTwelve - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTwelve.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            CaveSystem caves = new CaveSystem(lines);

            int pathsCount = caves.CountPathsFromTo("start", "end");

            Console.WriteLine($"There are {pathsCount} different paths going into small caves not more than once");

            Console.WriteLine("DayTwelve - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayTwelve - Part Two");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTwelve.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            CaveSystem caves = new CaveSystem(lines);

            int pathsCount = caves.CountLongPathsFromTo("start", "end");

            Console.WriteLine($"There are {pathsCount} different paths going into small caves not more than once");

            Console.WriteLine("DayTwelve - End of part Two");
        }
    }
}
