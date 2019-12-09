using System;

namespace AdventOfCode2019
{
    partial class Program
    {
        public class DayOne
        {
            public static void PartOne()
            {
                string inputLines = InputHelper.GetInputFromFile("1");

                int sum = 0;
                foreach (string line in inputLines.Split(Environment.NewLine))
                {
                    int value = (int)Math.Floor(int.Parse(line) / 3.0) - 2;
                    sum += value;
                }

                Console.WriteLine(sum);
            }

            public static void PartTwo()
            {
                string inputLines = InputHelper.GetInputFromFile("1");

                int sum = 0;
                foreach (string line in inputLines.Split(Environment.NewLine))
                {
                    int value = (int)Math.Floor(int.Parse(line) / 3.0) - 2;
                    int additionnal = (int)Math.Floor(value / 3.0) - 2;
                    while (additionnal > 0)
                    {
                        value += additionnal;
                        additionnal = (int)Math.Floor(additionnal / 3.0) - 2;
                    }
                    sum += value;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
