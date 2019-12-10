using System;
using System.Collections.Generic;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DayNine
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("9");

            Intcode i = new Intcode(data);
            i.InputQueue.Enqueue(1);
            i.Run();
        }

        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("9");

            Intcode i = new Intcode(data);
            i.InputQueue.Enqueue(2);
            i.Run();
        }
    }
}
