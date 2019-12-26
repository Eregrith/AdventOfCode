using AdventOfCode2019.Intcode;
using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    public static class DayFive
    {
        public static void PartOneAndTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("5");

            IntcodeComputer i = new IntcodeComputer(data);
            i.Run();
        }

        public static void Trace()
        {
            long[] data = InputHelper.GetIntcodeFromFile("5");

            IntcodeComputer i = new IntcodeComputer(data, IntcodeMode.Trace);
            i.Run();

            File.WriteAllText(InputHelper.GetOutputPathForFile("5_trace"), String.Join(Environment.NewLine, i.GetTrace()));
        }
    }
}
