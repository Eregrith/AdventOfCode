using System.Drawing;
using AdventOfCode.Elves.DataHelpers;
using AdventOfCode.Elves.IOHelpers;

namespace AdventOfCode2024.Days;

public class Day06(IPuzzleInputHelper puzzleInputHelper)
{
    public void Part1()
    {
        int numberOfVisitedPlaces = 0;

        var map = puzzleInputHelper.GetInputMatrix("Day06.txt");
        var visited = new bool[map.Length, map[0].Length];
        int w = map[0].Length;
        int h = map.Length;
        (int x, int y) guardPos = (0, 0);
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                if (!IsGuard(map, y, x)) continue;
                guardPos = (x, y);
            }
        }

        var actionCycle = new[] { MoveUp, MoveRight, MoveDown, MoveLeft };
        int actionCount = 4;
        var move = actionCycle[0];
        while (!IsOutOfBonds(guardPos, h, w))
        {
            if (!visited[guardPos.y, guardPos.x])
            {
                visited[guardPos.y, guardPos.x] = true;
                numberOfVisitedPlaces++;
            }
            var nextPos = move(guardPos);
            if (!IsOutOfBonds(nextPos, h, w) && IsBlocked(map, nextPos))
            {
                move = actionCycle[(Array.IndexOf(actionCycle, move) + 1) % actionCount];
            }
            else
            {
                guardPos = nextPos;
            }
        }

        Console.WriteLine($"Number of different visited places: {numberOfVisitedPlaces}");
    }

    private bool IsBlocked(char[][] map, (int x, int y) pos)
    {
        if (map[pos.y][pos.x] == '#')
        {
            return true;
        }

        return false;
    }

    private bool IsOutOfBonds((int x, int y) guardPos, int h, int w)
    {
        return guardPos.y < 0 || guardPos.y >= h
            || guardPos.x < 0 || guardPos.x >= w;
    }

    private bool IsGuard(char[][] map, int y, int x)
    {
        return map[y][x] == '^';
    }
    
    private static (int x, int y) MoveUp((int x, int y) guardPos)
    {
        return (guardPos.x, guardPos.y - 1);
    }
    
    private static (int x, int y) MoveDown((int x, int y) guardPos)
    {
        return (guardPos.x, guardPos.y + 1);
    }
    
    private static (int x, int y) MoveLeft((int x, int y) guardPos)
    {
        return (guardPos.x - 1, guardPos.y);
    }
    
    private static (int x, int y) MoveRight((int x, int y) guardPos)
    {
        return (guardPos.x + 1, guardPos.y);
    }
}