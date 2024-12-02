using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day02
{
    private readonly IPuzzleInputHelper _puzzleInputHelper;

    public Day02(IPuzzleInputHelper puzzleInputHelper)
    {
        _puzzleInputHelper = puzzleInputHelper;
    }
    
    public void Part1()
    {
        List<List<int>> input = _puzzleInputHelper.GetInputLines("Day02.txt")
            .Select(l => l.Split(" ").Select(int.Parse).ToList()).ToList();
        int safeCount = input.Count(i => IsSafeReport(i));
        Console.WriteLine($"Number of safe reports: {safeCount}");
    }
    
    public void Part2()
    {
        List<List<int>> input = _puzzleInputHelper.GetInputLines("Day02.txt")
            .Select(l => l.Split(" ").Select(int.Parse).ToList()).ToList();
        int safeCount = input.Count(i => IsSafeReport(i, true));
        Console.WriteLine($"Number of safe reports: {safeCount}");
    }
    
    public void Part3()
    {
        List<List<int>> input = _puzzleInputHelper.GetInputLines("Day02.txt")
            .Select(l => l.Split(" ").Select(int.Parse).ToList()).ToList(); 
        input.ForEach(i => Console.WriteLine(String.Join(" ", i) + " safe: " + IsSafeReport(i, true)));
    }

    private bool IsSafeReport(List<int> report) => IsSafeReport(report, false);
    
    private bool IsSafeReport(List<int> report, bool tolerateOneBad)
    {
        bool safe = true;
        for (int i = 0; i < report.Count - 1; i++)
        {
            bool ascending = report[i] < report[i + 1];
            if (i > 0)
            {
                ascending = report[i - 1] < report[i];
            }
            bool safeWithNext = CompareSafeWith(report, i, i + 1, ascending);
            if (!safeWithNext)
            {
                safe = false;
                break;
            }
        }

        if (!safe)
        {
            if (!tolerateOneBad) return false;
            
            for (int i = 0; i < report.Count; i++)
            {
                if (IsSafeWithoutIndex(i, report))
                    return true;
            }
            return false;
        }
        return true;
    }

    private bool IsSafeWithoutIndex(int indexToRemove, List<int> report)
    {
        List<int> withoutIndex = report.Where((_, i) => i != indexToRemove).ToList();
        return IsSafeReport(withoutIndex);
    }

    private bool CompareSafeWith(List<int> report, int i, int j, bool ascending)
    {
        if (report[i] == report[j])
            return false;
        if (report[i] > report[j] && ascending)
            return false;
        if (report[i] < report[j] && !ascending)
            return false;
        if (Math.Abs(report[i] - report[j]) > 3)
            return false;
        return true;
    }
}