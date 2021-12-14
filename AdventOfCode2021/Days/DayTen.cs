using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Syntax;
using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Days
{
    internal class DayTen
    {
        public static void PartOne()
        {
            Console.WriteLine("DayTen - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTen.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            SyntaxChecker syntaxChecker = new SyntaxChecker(lines);

            int score = syntaxChecker.GetScore();
            
            Console.WriteLine($"The score of the syntax check is {score}");

            Console.WriteLine("DayTen - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayTen - Part Two");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayTen.txt");
            Console.WriteLine($"Input has {lines.Count} lines");



            Console.WriteLine("DayTen - End of part Two");
        }
    }
}
