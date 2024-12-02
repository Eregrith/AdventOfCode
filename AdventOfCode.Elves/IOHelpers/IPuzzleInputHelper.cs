using System.Collections.Generic;

namespace AdventOfCode.Elves.IOHelpers
{
    public interface IPuzzleInputHelper
    {
        List<string> GetInputLines(string fileName);
        List<List<string>> GetInputLinesBatched(string fileName, string batchSeparationLine);
        char[][] GetInputMatrix(string fileName);
    }
}