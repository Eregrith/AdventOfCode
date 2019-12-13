using AdventOfCode2019.Intcode;
using System;

namespace AdventOfCode2019
{
    public static partial class DayTwo
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("2");

            IntcodeComputer i = new IntcodeComputer(data);

            Console.Write(i.Run(12, 2));
        }

        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("2");

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    IntcodeComputer i = new IntcodeComputer(data);
                    if (i.Run(noun, verb) == 19690720)
                    {
                        Console.WriteLine($"{noun} {verb}");
                        return;
                    }
                }
            }
        }
    }
}
