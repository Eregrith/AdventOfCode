using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{
    internal class BatteryBankJoltageChecker
    {
        internal int FindHighestJoltage(string batteryBank)
        {
            int bestBatteryIndex = FindHighestJoltageIndexFromIndex(batteryBank, 0, 1);
            char ten = batteryBank[bestBatteryIndex];
            bestBatteryIndex = FindHighestJoltageIndexFromIndex(batteryBank, bestBatteryIndex + 1, 0);
            char unit = batteryBank[bestBatteryIndex];

            return int.Parse($"{ten}{unit}");
        }

        private static int FindHighestJoltageIndexFromIndex(string batteryBank, int start, int endBufferSize)
        {
            int bestBatteryIndex = start;
            for (int i = start; i < batteryBank.Length - endBufferSize; i++)
            {
                if (batteryBank[i] > batteryBank[bestBatteryIndex])
                {
                    bestBatteryIndex = i;
                }
            }

            return bestBatteryIndex;
        }
    }

    internal class BatteryBankHeavyJoltageChecker
    {
        internal long FindHighestJoltage(string batteryBank)
        {
            char[] highestJoltageString = new char[12];
            int bestBatteryIndex = 0;
            int endBufferSize = 11;
            for (int i = 0; i < 12; i++)
            {
                bestBatteryIndex = FindHighestJoltageIndexFromIndex(batteryBank, bestBatteryIndex, endBufferSize);
                highestJoltageString[i] = batteryBank[bestBatteryIndex];
                bestBatteryIndex++;
                endBufferSize--;
            }

            return long.Parse(String.Join("", highestJoltageString));
        }

        private static int FindHighestJoltageIndexFromIndex(string batteryBank, int start, int endBufferSize)
        {
            int bestBatteryIndex = start;
            for (int i = start; i < batteryBank.Length - endBufferSize; i++)
            {
                if (batteryBank[i] > batteryBank[bestBatteryIndex])
                {
                    bestBatteryIndex = i;
                }
            }

            return bestBatteryIndex;
        }
    }

    internal class DayThree(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            List<String> lines = inputHelper.GetInputLines("DayThree.txt");
            long sum = 0;
            BatteryBankJoltageChecker checker = new BatteryBankJoltageChecker();

            foreach (string line in lines)
            {
                int bestJoltage = checker.FindHighestJoltage(line);
                sum += bestJoltage;
            }

            Console.WriteLine($"Part One: Sum of best joltages: {sum}");
        }

        public void PartTwo()
        {
            List<String> lines = inputHelper.GetInputLines("DayThree.txt");
            long sum = 0;
            BatteryBankHeavyJoltageChecker checker = new BatteryBankHeavyJoltageChecker();

            foreach (string line in lines)
            {
                long bestJoltage = checker.FindHighestJoltage(line);
                sum += bestJoltage;
            }

            Console.WriteLine($"Part Two: Sum of best joltages: {sum}");
        }
    }
}
