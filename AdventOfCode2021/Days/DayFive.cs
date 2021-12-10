using AdventOfCode.Elves.DataHelpers;
using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.HydrothermalVents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Days
{
    internal class DayFive
    {
        //5260 too low
        public static void PartOne()
        {
            Console.WriteLine("DayFive - Part One");
            List<VentLine> lines = PuzzleInputHelper.GetInputLines("DayFive.txt").Select(l => VentLine.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int width = lines.Max(l => Math.Max(l.Start.X, l.End.X));
            int height = lines.Max(l => Math.Max(l.Start.Y, l.End.Y));
            int[][] floor = new int[height][];
            for (int y = 0; y < height; y++)
            {
                floor[y] = new int[width];
                for (int x = 0; x < width; x++)
                {
                    floor[y][x] = 0;
                }
            }
            lines.Where(l => l.IsVerical || l.IsHorizontal)
                .ToList()
                .ForEach(l => l.MarkFloor(floor));

            Console.WriteLine($"Two lines overlap in exactly {floor.Sum(f => f.Count(c => c > 1))} points");
            Console.WriteLine("DayFive - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DayFive - Part Two");
            List<VentLine> lines = PuzzleInputHelper.GetInputLines("DayFive.txt").Select(l => VentLine.Parse(l)).ToList();
            Console.WriteLine($"Input has {lines.Count} lines");
            int width = lines.Max(l => Math.Max(l.Start.X, l.End.X));
            int height = lines.Max(l => Math.Max(l.Start.Y, l.End.Y));
            int[][] floor = new int[height][];
            for (int y = 0; y < height; y++)
            {
                floor[y] = new int[width];
                for (int x = 0; x < width; x++)
                {
                    floor[y][x] = 0;
                }
            }
            lines.ForEach(l => l.MarkFloor(floor));

            Console.WriteLine($"Two lines overlap in exactly {floor.Sum(f => f.Count(c => c > 1))} points");
            Console.WriteLine("DayFive - End of part Two");
        }
    }
}
