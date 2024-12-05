using AdventOfCode.Elves.DataHelpers;
using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day04(IPuzzleInputHelper puzzleInputHelper)
{
    private readonly IPuzzleInputHelper _puzzleInputHelper = puzzleInputHelper;

    public void Part1()
    {
        char[][] input = _puzzleInputHelper.GetInputMatrix("Day04.txt");
        int xmas = 0;
        
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == 'X')
                {
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x + 1, p.y));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x - 1, p.y));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x, p.y + 1));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x, p.y - 1));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x + 1, p.y + 1));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x - 1, p.y + 1));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x - 1, p.y - 1));
                    xmas += FindWord("XMAS", input, x, y, ((int x, int y) p) => (p.x + 1, p.y - 1));
                }
            }
        }
        
        Console.WriteLine($"Number of valid XMAS: {xmas}");
    }

    private int FindWord(string word, char[][] input, int x, int y, Func<(int x, int y), (int, int y)> move)
    {
        int found = 0;
        for (int i = 0; i < word.Length; i++)
        {
            if (x < 0 || x >= input[0].Length || y < 0 || y >= input.Length) return 0;
            if (input[y][x] != word[i]) return 0;
            if (i == word.Length - 1) found++;
            (x, y) = move((x, y));
        }
        return found;
    }

    public void Part2()
    {
        char[][] input = _puzzleInputHelper.GetInputMatrix("Day04.txt");
        int x_mas = 0;
        
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
                if (input[y][x] == 'A')
                {
                    int mCount = CountAtCorners(input, x, y, 'M');
                    int sCount = CountAtCorners(input, x, y, 'S');
                    if (mCount == 2 && sCount == 2)
                    {
                        if (input[y - 1][x - 1] != input[y + 1][x + 1])
                            x_mas++;
                    }
                }
            }
        }
        Console.WriteLine($"Number of valid X-MAS: {x_mas}");
    }

    private int CountAtCorners(char[][] input, int x, int y, char letter)
    {
        int count = 0;
        if (x > 0 && y > 0 && input[y - 1][x - 1] == letter) count++;
        if (x < input[0].Length - 1 && y > 0 && input[y - 1][x + 1] == letter) count++;
        if (x > 0 && y < input.Length - 1 && input[y + 1][x - 1] == letter) count++;
        if (x < input[0].Length - 1 && y < input.Length - 1 && input[y + 1][x + 1] == letter) count++;
        return count;
    }
}