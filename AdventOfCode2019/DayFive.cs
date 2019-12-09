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
            string input = InputHelper.GetInputFromFile("5");

            Intcode i = new Intcode(input.Split(",").Select(i => int.Parse(i)).ToArray());
            i.Run();
        }
    }
}
