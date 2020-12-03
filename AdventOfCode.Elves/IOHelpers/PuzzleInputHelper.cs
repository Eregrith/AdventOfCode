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
            if (!File.Exists("Inputs/" + fileName))
            {
                Console.WriteLine($"File not found: {fileName}. Don't forget to set Copy if newer");
                return null;
            }
            return File.ReadAllLines("Inputs/" + fileName).ToList();
        }

        public static char[][] GetInputMatrix(string fileName)
        {
            if (!File.Exists("Inputs/" + fileName))
            {
                Console.WriteLine($"File not found: {fileName}. Don't forget to set Copy if newer");
                return null;
            }
            return File.ReadAllLines("Inputs/" + fileName).Select(l => l.ToArray()).ToArray();
        }
    }
}
