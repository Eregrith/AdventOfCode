using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Days
{
    public static class DayThree
    {
        public static void PartOne()
        {
            Console.WriteLine("Day three - Part One");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayThree.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            int width = lines[0].Length;
            List<int> ones = new List<int>(width);
            for (int i = 0; i < width; i++) ones.Add(0);

            lines.ForEach(l =>
            {
                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i] == '1')
                    {
                        ones[i]++;
                    }
                }
            });

            string mostCommon = "";
            string leastCommon = "";
            for (int i = 0; i < width; i++)
            {
                if (ones[i] >= (lines.Count / 2))
                {
                    mostCommon += "1";
                    leastCommon += "0";
                }
                else
                {
                    mostCommon += "0";
                    leastCommon += "1";
                }
            }


            Console.WriteLine($"Most/least commons are {mostCommon} and {leastCommon}");
            Console.WriteLine($"In decimal {Convert.ToInt32(mostCommon, 2)} and {Convert.ToInt32(leastCommon, 2)}");
            Console.WriteLine($"Product is {Convert.ToInt32(mostCommon, 2) * Convert.ToInt32(leastCommon, 2)}");

            Console.WriteLine("Day three - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day three - Part Twp");
            List<string> lines = PuzzleInputHelper.GetInputLines("DayThree.txt");
            Console.WriteLine($"Input has {lines.Count} lines");
            int pos = 0;
            IEnumerable<string> oxygen = lines.ToList();
            IEnumerable<string> co2 = lines.ToList();

            while (oxygen.Count() > 1)
            {
                char mostCommonAtPos = GetMostCommonAtPos(oxygen, pos);
                Console.WriteLine($"After applying filter with a {mostCommonAtPos} in pos {pos}");
                oxygen = oxygen.Where(o => o[pos] == mostCommonAtPos).ToList();
                Console.WriteLine($"We have {oxygen.Count()} oxygen left");
                pos++;
            }
            pos = 0;
            while (co2.Count() > 1)
            {
                char leastCommonAtPos = GetMostCommonAtPos(co2, pos) == '1' ? '0' : '1';
                Console.WriteLine($"After applying filter with a {leastCommonAtPos} in pos {pos}");
                co2 = co2.Where(c => c[pos] == leastCommonAtPos).ToList();
                Console.WriteLine($"We have {co2.Count()} co2 left");
                pos++;
            }

            string o = oxygen.First();
            string c = co2.First();
            Console.WriteLine($"Oxygen/Co2 are {o} and {c}");
            Console.WriteLine($"In decimal {Convert.ToInt32(o, 2)} and {Convert.ToInt32(c, 2)}");
            Console.WriteLine($"Product is {Convert.ToInt32(o, 2) * Convert.ToInt32(c, 2)}");

            Console.WriteLine("Day three - End of part Two");
        }

        private static char GetMostCommonAtPos(IEnumerable<string> list, int pos)
        {
            int ones = list.Count(o => o[pos] == '1');
            Console.WriteLine($"There are {ones} ones at pos {pos}");
            return ones >= ((float)list.Count() / 2.0) ? '1' : '0';
        }
    }
}
