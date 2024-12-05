using System.Text.RegularExpressions;
using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day03(IPuzzleInputHelper puzzleInputHelper)
{
    private readonly IPuzzleInputHelper _puzzleInputHelper = puzzleInputHelper;

    public void Part1()
    {
        int sum = 0;
        List<string> input = _puzzleInputHelper.GetInputLines("Day03.txt");
        foreach (var line in input)
        {
            Regex r = new Regex(@"mul\((?<a>\d+),(?<b>\d+)\)");
            MatchCollection matches = r.Matches(line);
            foreach (Match m in matches)
            {
                int a = int.Parse(m.Groups["a"].Value);
                int b = int.Parse(m.Groups["b"].Value);
                sum += a * b;
            }
        }
        
        Console.WriteLine($"Sum of uncorrupted mult operations is: {sum}");
    }

    public void Part2()
    {
        int sum = 0;
        List<string> input = _puzzleInputHelper.GetInputLines("Day03.txt");
        bool active = true;
        foreach (var line in input)
        {
            Regex r = new Regex(@"(?<op>mul\((?<a>\d+),(?<b>\d+)\)|do\(\)|don't\(\))");
            MatchCollection matches = r.Matches(line);

            foreach (Match m in matches)
            {
                if (m.Groups["op"].Value == "do()")
                {
                    active = true;
                }
                if (m.Groups["op"].Value == "don't()")
                {
                    active = false;
                }
                if (m.Groups["op"].Value.StartsWith("mul") && active)
                {
                    int a = int.Parse(m.Groups["a"].Value);
                    int b = int.Parse(m.Groups["b"].Value);
                    sum += a * b;
                }
            }
        }
        
        Console.WriteLine($"Sum of active uncorrupted mult operations is: {sum}");
    }
}