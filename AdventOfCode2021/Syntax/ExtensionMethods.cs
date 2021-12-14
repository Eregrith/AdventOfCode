using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Syntax
{
    internal static class ExtensionMethods
    {
        public static bool IsBlockOpening(this char c)
        {
            return c == '('
                || c == '['
                || c == '{'
                || c == '<';
        }

        public static char GetClosingChar(this char c)
        {
            switch (c)
            {
                case '(': return ')';
                case '[': return ']';
                case '{': return '}';
                case '<': return '>';
                default: return (char)0;
            }
        }
    }
}
