using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AdventOfCode2023.Days
{
    internal static class DayOne
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day one - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").ToList();
            Console.WriteLine($"Input has {lines.Count} lines");

            int sum = lines.Select(GroupDigits).Sum();

            Console.WriteLine($"Sum is : {sum}");
            Console.WriteLine("Day one - End of part One");
        }

        internal static int GroupDigits(string line)
        {
            char firstDigit = line.First(Char.IsDigit);
            var lastDigit = line.Last(Char.IsDigit);
            return int.Parse($"{firstDigit}{lastDigit}");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day one - Part Two");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayOne.txt").ToList();
            Console.WriteLine($"Input has {lines.Count} lines");

            int sum = lines.Select(DespellDigits).Select(GroupDigits).Sum();

            Console.WriteLine($"Sum is : {sum}");
            Console.WriteLine("Day one - End of part Two");
        }

        private static readonly List<string> SpelledDigits = new()
        {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };

        public static string DespellDigits(string input)
        {
            StringBuilder result = new StringBuilder();
            bool skipNextChar = false;
            for (int i = 0; i < input.Length; i++)
            {
                int index = SpelledDigits.FindIndex(
                    digit =>
                        string.Compare(digit, 0, input, i, digit.Length) == 0);
                if (index >= 0)
                {
                    result.Append(index.ToString());
                    i += SpelledDigits[index].Length - 2;
                    skipNextChar = true;
                }
                else
                {
                    if (!skipNextChar)
                        result.Append(input[i]);
                    skipNextChar = false;
                }
            }
            return result.ToString();
        }
    }
}
