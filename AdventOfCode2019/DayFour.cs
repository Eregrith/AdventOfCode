using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2019
{
    public static class DayFour
    {
        public static void PartOne()
        {
            Console.WriteLine("Matches: " + Enumerable.Range(248345, 746315 - 248345 + 1).Count(i => Regex.IsMatch(i.ToString(), @"(\d)\1") && Regex.IsMatch(i.ToString(), @"^(?=\d{6}$)0*1*2*3*4*5*6*7*8*9*$")));
        }

        public static void PartTwo()
        {
            Console.WriteLine("Matches: " + Enumerable.Range(248345, 746315 - 248345 + 1).Count(i => Regex.IsMatch(i.ToString(), @"^(?=[0-9]{6}$)(?=(?:.*([0-9])(?!\1))?([0-9])\2(?!\2))(?:0|1(?!0)|2(?![01])|3(?![0-2])|4(?![0-3])|5(?![0-4])|6(?![0-5])|7(?![0-6])|8(?![0-7])|9(?![0-8]))+$")));
        }
    }
}
