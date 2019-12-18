using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public static class DaySixteen
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("16");
            List<int> phase = input.ToCharArray().Select(c => c - '0').ToList();
            List<int> pattern = new List<int> { 0, 1, 0, -1 };

            for (int p = 0; p < 100; p++)
            {
                phase = NextPhase(phase, pattern, 1);
            }
            Console.WriteLine("Final phase is " + String.Join(' ', phase.Take(8)));
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("16");
            List<int> phase = input.ToCharArray().Select(c => c - '0').ToList();
            List<int> pattern = new List<int> { 0, 1, 0, -1 };
            int offset = int.Parse(String.Join("", phase.Take(7)));

            for (int p = 0; p < 100; p++)
            {
                phase = NextPhase(phase, pattern, 10000);
            }
            Console.WriteLine("Final phase is " + String.Join(' ', phase.Skip(offset).Take(8)));
        }

        private static List<int> NextPhase(List<int> phase, List<int> pattern, int repeatPhase)
        {
            List<int> nextPhase = new List<int>();
            int length = phase.Count;
            for (int i = 1; i <= length; i++)
            {
                nextPhase.Add(SumPhase(phase, pattern, i));
            }
            return nextPhase;
        }

        private static int SumPhase(List<int> phase, List<int> pattern, int stretch)
        {
            int c = 1;
            int sum = 0;
            foreach (int p in phase)
            {
                sum += p * pattern[c / stretch];
                c = (c + 1) % (pattern.Count * stretch);
            }
            return Math.Abs(sum % 10);
        }
    }
}
