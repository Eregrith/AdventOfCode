using AdventOfCode.Elves.DataHelpers;
using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class DayThree
    {
        private const int AnswerToPartOne = 232;

        public static void PartOne()
        {
            Console.WriteLine("Day Three - Part One");
            char[][] trees = PuzzleInputHelper.GetInputMatrix("DayThree.txt");

            int ouchies = Weeeeeeeeeeeee(trees, 3, 1);

            string displayRectangle = MatrixHelper<char>.GetDisplayRectangle(trees, new Rectangle(-5, -5, 20, 20), MatrixWrap.WrapHorizontally | MatrixWrap.WrapVertically);
            Console.WriteLine(displayRectangle);

            Console.WriteLine($"You have {ouchies} ouchies. Oof!");

            Console.WriteLine("Day Three - End of Part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day Three - Part Two");
            char[][] trees = PuzzleInputHelper.GetInputMatrix("DayThree.txt");

            long ouchies = Weeeeeeeeeeeee(trees, 1, 1);
            ouchies *= AnswerToPartOne;
            ouchies *= Weeeeeeeeeeeee(trees, 5, 1);
            ouchies *= Weeeeeeeeeeeee(trees, 7, 1);
            ouchies *= Weeeeeeeeeeeee(trees, 1, 2);

            Console.WriteLine($"You have {ouchies} ouchies in your kamikaze run. Oof!");

            Console.WriteLine("Day Three - End of Part Two");
        }

        private static int Weeeeeeeeeeeee(char[][] trees, int right, int down)
        {
            int x = right;
            int bong = 0;
            for (int y = down; y < trees.Length; y += down, x = (x + right) % trees[0].Length)
            {
                if (trees[y][x] != '.' && trees[y][x] != 'O')
                {
                    bong++;
                    trees[y][x] = 'X';
                }
                else
                    trees[y][x] = 'O';
            }
            return bong;
        }
    }
}
