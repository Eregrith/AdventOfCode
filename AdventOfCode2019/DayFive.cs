using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DayFive
    {
        public static void PartOneAndTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("5");

            Intcode i = new Intcode(data);
            i.Run();
        }
    }
}
