using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Bingo;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Days
{
    public static class DayFour
    {
        public static void PartOne()
        {
            Console.WriteLine("Day four - Part One");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatchedStatic("DayFour.txt", "");
            Console.WriteLine($"Input has {lines.Count} lines");

            BingoSystem bingo = BingoFactory.Parse(lines);

            while (!bingo.ThereIsAWinner)
            {
                bingo.DrawNextNumber();
                bingo.DisplayGrid(0);
            }

            Console.WriteLine("There is a winner !");

            Console.WriteLine("Day four - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day three - Part Twp");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatchedStatic("DayFour.txt", "");
            Console.WriteLine($"Input has {lines.Count} lines");

            BingoSystem bingo = BingoFactory.Parse(lines);

            while (!bingo.AllHaveWon)
            {
                bingo.DrawNextNumber();
            }

            Console.WriteLine("All have won !");

            Console.WriteLine("Day four - End of part Two");
        }
    }
}
