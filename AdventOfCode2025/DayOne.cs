using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleToAttribute("AdventOfCode2025.Tests")]
namespace AdventOfCode2025
{
    internal class DayOne(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            List<String> lines = inputHelper.GetInputLines("DayOne.txt");
            int sum = 50;
            int hits = 0;
            foreach (string line in lines)
            {
                int direction = 1;
                if (line[0] == 'L') direction = -1;
                int value = int.Parse(line.Substring(1));
                sum = value * direction + sum;
                sum %= 100;
                if (sum == 0) hits++;
            }

            Console.WriteLine($"Part One: Number of 0 hits {hits}");
        }

        //7851 too high
        //7371 too high
        //6642 too low
        public void PartTwo()
        {
            List<String> lines = inputHelper.GetInputLines("DayOne.txt");
            int sum = 50;
            int hits = 0;

            bool startedOn0 = false;
            foreach (string line in lines)
            {
                startedOn0 = sum == 0;
                int direction = 1;
                if (line[0] == 'L') direction = -1;
                int value = int.Parse(line.Substring(1));
                while (value >= 100)
                {
                    value -= 100;
                    hits++;
                }
                if (value == 0) continue;
                sum = value * direction + sum;
                if (sum < 0)
                {
                    sum += 100;
                    if (!startedOn0)
                    {
                        hits++;
                    }
                }
                else if (sum > 99)
                {
                    sum -= 100;
                    hits++;
                }
                else if (sum == 0)
                {
                    hits++;
                }
            }

            Console.WriteLine($"Part Two: Number of 0 mid-rotation hits {hits}");
        }
    }
}
