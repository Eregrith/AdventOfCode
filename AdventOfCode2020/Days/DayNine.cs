using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class DayNine
    {
        private static List<BigInteger> GetValidSumsFor(IEnumerable<BigInteger> cypher)
        {
            List<BigInteger> validSums = cypher.Take(24).SelectMany((value, index) =>
            {
                return cypher.Skip(index + 1).Select(c => c + value);
            }).ToList();
            validSums.Add(cypher.ElementAt(24));
            return validSums;
        }

        public static void PartOne()
        {
            Console.WriteLine("Day Nine - Part One");
            List<BigInteger> inputs = PuzzleInputHelper.GetInputLinesStatic("DayNine.txt")
                .Select(BigInteger.Parse).ToList();
            var valids = inputs.Select((value, index) =>
            {
                if (index < 25)
                    return (value, true);
                return (value, GetValidSumsFor(inputs.Skip(index - 25).Take(25)).Contains(value));
            });
            Console.WriteLine($"The first number to not respect a valid sum is {valids.First(i => !i.Item2).Item1}");
            Console.WriteLine("Day Nine - End of Part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day Nine - Part Two");
            List<BigInteger> inputs = PuzzleInputHelper.GetInputLinesStatic("DayNine.txt")
                .Select(BigInteger.Parse).ToList();
            BigInteger answerToPartOne = 373803594;
            BigInteger runningSum = inputs[0];
            int minIndex = 0;
            int maxIndex = 0;
            while (runningSum != answerToPartOne) {
                if (runningSum > answerToPartOne || runningSum < 0)
                {
                    runningSum -= inputs[minIndex];
                    minIndex++;
                }
                else if (runningSum < answerToPartOne)
                {
                    maxIndex++;
                    runningSum += inputs[maxIndex];
                }
            }
            Console.WriteLine($"Sum of numbers between {minIndex} and {maxIndex} indexes are {answerToPartOne}");
            BigInteger sum = 0;
            BigInteger min = 0;
            BigInteger max = 0;
            for (int i = minIndex; i < maxIndex + 1; i++)
            {
                if (min == 0 || inputs[i] < min)
                    min = inputs[i];
                if (max < inputs[i])
                    max = inputs[i];
                sum += inputs[i];
            }
            Console.WriteLine($"Sum is {sum}");
            Console.WriteLine($"min + max = {min + max}");
            Console.WriteLine("Day Nine - End of Part Two");
        }
    }
}
