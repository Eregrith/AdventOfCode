﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static partial class DayTwo
    {
        public static void PartOne()
        {
            string input = InputHelper.GetInputFromFile("2");

            Intcode i = new Intcode(input.Split(",").Select(i => int.Parse(i)).ToArray());

            Console.Write(i.Run(12, 2));
        }

        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("2");

            for (int noun = 0; noun < 100; noun++)
            {
                for (int verb = 0; verb < 100; verb++)
                {
                    Intcode i = new Intcode(input.Split(",").Select(i => int.Parse(i)).ToArray());
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
