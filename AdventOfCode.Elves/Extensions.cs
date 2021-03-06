﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public static bool IsHexadecimalColor(this string value)
        {
            return value.StartsWith("#")
                && value.Length == 7
                && value.Substring(1).All(c => "0123456789abcdef".Contains(c));
        }
    }
}
