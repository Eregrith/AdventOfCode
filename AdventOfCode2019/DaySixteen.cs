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
                phase = NextPhase(phase, pattern);
            }
            Console.WriteLine("Final phase is " + String.Join(' ', phase.Take(8)));
        }

        private static List<int> NextPhase(List<int> phase, List<int> pattern)
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

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("16");
            int trailerLength = (input.Length * 10000) - int.Parse(input.Substring(0, 7));
            string longInput = input.Substring(input.Length - trailerLength % 650);
            for (int i = 0; i < trailerLength / 650; i++)
            {
                longInput += input;
            }
            Console.WriteLine("Long input has length :" + longInput.Length);

            List<int> list = longInput.ToCharArray().Select(c => c - '0').ToList();
            for (int fft = 0; fft < 100; fft++)
            {
                int sum = 0;
                for (int l = list.Count - 1; l >= 0; l--)
                {
                    sum += list[l];
                    list[l] = sum % 10;
                }
            }
            Console.WriteLine("After 100 FFT: " + String.Join("", list.Take(8)));
        }
    }
}
