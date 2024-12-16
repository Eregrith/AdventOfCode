using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day05(IPuzzleInputHelper puzzleInputHelper)
{
    private readonly IPuzzleInputHelper _puzzleInputHelper = puzzleInputHelper;

    public void Part1()
    {
        var lines = _puzzleInputHelper.GetInputLinesBatched("Day05.txt", String.Empty);

        var printRules = lines[0].Select(pr =>
        {
            var rule = pr.Split("|");
            return new Tuple<string, string>(rule[0], rule[1]);
        }).ToList();
        int sum = 0;
        foreach (string printOrderLine in lines[1])
        {
            var pagesToPrint = printOrderLine.Split(",");
            if (IsInOrder(pagesToPrint, printRules))
            {
                var middlePage = pagesToPrint[pagesToPrint.Length / 2];
                sum += int.Parse(middlePage);
            }
        }

        Console.WriteLine($"Sum of valid rules middle numbers: {sum}");
    }

    private bool IsInOrder(string[] pagesToPrint, List<Tuple<string, string>> rules)
    {
        foreach (var rule in rules)
        {
            if (!RuleIsSatisfiedIn(pagesToPrint, rule))
            {
                return false;
            }
        }
        return true;
    }

    private bool RuleIsSatisfiedIn(string[] pagesToPrint, Tuple<string,string> rule)
    {
        var indexOfFirstPage = Array.IndexOf(pagesToPrint, rule.Item1);
        if (indexOfFirstPage < 0) return true;
        var indexOfSecondPage = Array.IndexOf(pagesToPrint, rule.Item2);
        if (indexOfSecondPage < 0) return true;
        return indexOfFirstPage < indexOfSecondPage;
    }

    public void Part2()
    {
        var lines = _puzzleInputHelper.GetInputLinesBatched("Day05.txt", String.Empty);

        var printRules = lines[0].Select(pr =>
        {
            var rule = pr.Split("|");
            return new Tuple<string, string>(rule[0], rule[1]);
        }).ToList();
        int sum = 0;
        foreach (string printOrderLine in lines[1])
        {
            var pagesToPrint = printOrderLine.Split(",");
            if (!IsInOrder(pagesToPrint, printRules))
            {
                pagesToPrint = PutInOrder(pagesToPrint, printRules);
                var middlePage = pagesToPrint[pagesToPrint.Length / 2];
                sum += int.Parse(middlePage);
            }
        }

        Console.WriteLine($"Sum of updated invalid rules middle numbers: {sum}");
    }

    private string[] PutInOrder(string[] pagesToPrint, List<Tuple<string,string>> printRules)
    {
        var pages = pagesToPrint.ToList();
        for (int i = 0; i < printRules.Count; i++)
        {
            var rule = printRules[i];
            var indexOfFirstPage = pages.IndexOf(rule.Item1);
            var indexOfSecondPage = pages.IndexOf(rule.Item2);
            if (indexOfFirstPage >= 0 && indexOfSecondPage >= 0 && indexOfFirstPage > indexOfSecondPage)
            {
                pages[indexOfFirstPage] = rule.Item2;
                pages[indexOfSecondPage] = rule.Item1;
                i = 0;
            }
        }
        return pages.ToArray();
    }
}