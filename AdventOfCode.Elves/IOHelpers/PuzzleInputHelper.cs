using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Elves.IOHelpers
{
    public class PuzzleInputHelper : IPuzzleInputHelper
    {
        public static List<string> GetInputLinesStatic(string fileName) => new PuzzleInputHelper().GetInputLines(fileName);
        
        public List<string> GetInputLines(string fileName)
        {
            if (!File.Exists("Inputs/" + fileName))
            {
                Console.WriteLine($"File not found: {fileName}. Don't forget to set Copy if newer");
                return new List<string>();
            }
            return File.ReadAllLines("Inputs/" + fileName).ToList();
        }

        public static List<List<string>> GetInputLinesBatchedStatic(string fileName, string batchSeparationLine)
            => new PuzzleInputHelper().GetInputLinesBatched(fileName, batchSeparationLine);
        
        public List<List<string>> GetInputLinesBatched(string fileName, string batchSeparationLine)
        {
            List<string> allLines = GetInputLinesStatic(fileName);
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

        public static char[][] GetInputMatrixStatic(string fileName)
            => new PuzzleInputHelper().GetInputMatrix(fileName);
        
        public char[][] GetInputMatrix(string fileName)
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
