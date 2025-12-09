using AdventOfCode.Elves;
using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{
    internal class DaySix(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            List<String[]> lines = inputHelper.GetInputLines("DaySix.txt").Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();
            long sum = 0;
            int col = 0;

            while (col < lines[0].Length)
            {
                List<long> columnValues = new List<long>();
                for (int l = 0; l < lines.Count - 1; l++)
                {
                    columnValues.Add(long.Parse(lines[l][col]));
                }
                string op = lines[lines.Count - 1][col];
                if (op == "+")
                {
                    sum += columnValues.Sum();
                }
                else if (op == "*")
                {
                    long product = 1;
                    foreach (long v in columnValues)
                    {
                        product *= v;
                    }
                    sum += product;
                }
                col++;
            }

            Console.WriteLine($"Part One: Grand total is {sum}");
        }

        public void PartTwo()
        {
            List<String> lines = inputHelper.GetInputLines("DaySix.txt");
            long sum = 0;
            int col = lines[0].Length - 1;
            List<long> columnValues = new List<long>();

            while (col >= 0)
            {
                string number = "";
                for (int l = 0; l < lines.Count - 1; l++)
                {
                    if (lines[l][col].IsDigit())
                    {
                        number += lines[l][col];
                    }
                }
                if (number == "")
                {
                    col--;
                    continue;
                }
                columnValues.Add(long.Parse(number));
                
                if (lines[lines.Count - 1][col] == '+')
                {
                    sum += columnValues.Sum();
                    columnValues.Clear();
                }
                else if (lines[lines.Count - 1][col] == '*')
                {
                    long product = 1;
                    foreach (long v in columnValues)
                    {
                        product *= v;
                    }
                    sum += product;
                    columnValues.Clear();
                }
                col--;
            }


            Console.WriteLine($"Part Two: Grand total is {sum}");
        }
    }
}
