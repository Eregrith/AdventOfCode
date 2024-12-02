using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day01
{
    private readonly IPuzzleInputHelper _puzzleInputHelper;

    public Day01(IPuzzleInputHelper puzzleInputHelper)
    {
        _puzzleInputHelper = puzzleInputHelper;
    }
    
    public void Part1()
    {
        List<string> input = _puzzleInputHelper.GetInputLines("Day01.txt");

        List<int> a = new List<int>();
        List<int> b = new List<int>();
        foreach (var line in input)
        {
            var parts = line.Split("   ");
            a.Add(int.Parse(parts[0]));
            b.Add(int.Parse(parts[1]));
        }
        a.Sort();
        b.Sort();
        int sumOfDifferences = a.Zip(b).Select(pair => Math.Abs(pair.Second - pair.First)).Sum();
        
        Console.WriteLine($"Sum of differences is: {sumOfDifferences}");
    }
    public void Part2()
    {
        List<string> input = _puzzleInputHelper.GetInputLines("Day01.txt");

        List<int> a = new List<int>();
        List<int> b = new List<int>();
        foreach (var line in input)
        {
            var parts = line.Split("   ");
            a.Add(int.Parse(parts[0]));
            b.Add(int.Parse(parts[1]));
        }

        int similarityScore = 0;
        foreach (int left in a)
        {
            similarityScore += b.Count(n => n == left) * left;
        }
        
        Console.WriteLine($"Similarity score is: {similarityScore}");
    }
}