using AdventOfCode2019.Intcode;
using System;
using System.IO;

namespace AdventOfCode2019
{
    public static class DayNine
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("9");

            IntcodeComputer i = new IntcodeComputer(data);
            i.InputQueue.Enqueue(1);
            i.Run();
        }

        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("9");

            IntcodeComputer i = new IntcodeComputer(data);
            i.InputQueue.Enqueue(2);
            i.Run();
        }
        public static void Trace()
        {
            long[] data = InputHelper.GetIntcodeFromFile("9");

            IntcodeComputer i = new IntcodeComputer(data, IntcodeMode.Trace);
            i.Run();

            File.WriteAllText(InputHelper.GetOutputPathForFile("9_trace"), String.Join(Environment.NewLine, i.GetTrace()));
        }
    }
}
