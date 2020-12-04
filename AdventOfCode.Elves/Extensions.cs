using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Elves
{
    public static class Extensions
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static bool IsBetween(this int x, int min, int max)
        {
            return x <= max && x >= min;
        }
    }
}
