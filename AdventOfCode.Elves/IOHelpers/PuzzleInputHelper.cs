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
                return new List<string>();
            }
            return File.ReadAllLines("Inputs/" + fileName).ToList();
        }

        public static List<List<string>> GetInputLinesBatched(string fileName, string batchSeparationLine)
        {
            List<string> allLines = GetInputLines(fileName);
            List<List<string>> batchedLines = new List<List<string>>();
            List<string> currentBatch = new List<string>();
            foreach (string line in allLines)
            {
                if (line == batchSeparationLine)
                {
                    batchedLines.Add(currentBatch);
                    currentBatch = new List<string>();
                }
                else
                    currentBatch.Add(line);
            }
            batchedLines.Add(currentBatch);
            return batchedLines;
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
