using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Elves.IOHelpers
{
    public class PuzzleInputHelper
    {
        public static List<string> GetInputLines(string fileName)
        {
            return File.ReadAllLines("Inputs/" + fileName).ToList();
        }
    }
}
