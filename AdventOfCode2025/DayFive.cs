using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{
    internal class DayFive(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            List<List<String>> lines = inputHelper.GetInputLinesBatched("DayFive.txt", String.Empty);
            List<(long min, long max)> freshIdsRanges = lines[0].Select(l => {
                string[] parts = l.Split('-');
                return (long.Parse(parts[0]), long.Parse(parts[1]));
            }).ToList();

            int freshCount = 0;
            foreach (var idStr in lines[1])
            {
                long id = long.Parse(idStr);
                if (freshIdsRanges.Any(r => id >= r.min && id <= r.max))
                {
                    freshCount++;
                }
            }

            Console.WriteLine($"Part One: Count of fresh IDs: {freshCount}");
        }

        public void PartTwo()
        {
            List<List<String>> lines = inputHelper.GetInputLinesBatched("DayFive.txt", String.Empty);
            List<(long min, long max)> freshIdsRanges = lines[0].Select(l => {
                string[] parts = l.Split('-');
                return (long.Parse(parts[0]), long.Parse(parts[1]));
            }).ToList();

            List<string> mergedRanges = new List<string>();
            freshIdsRanges = freshIdsRanges.OrderBy(r => r.min).ToList();
            (long min, long max) currentRange = freshIdsRanges[0];
            for (int i = 1; i < freshIdsRanges.Count; i++)
            {
                var range = freshIdsRanges[i];
                if (range.min <= currentRange.max + 1)
                {
                    currentRange.max = Math.Max(currentRange.max, range.max);
                }
                else
                {
                    mergedRanges.Add($"{currentRange.min}-{currentRange.max}");
                    currentRange = range;
                }
            }
            mergedRanges.Add($"{currentRange.min}-{currentRange.max}");
            freshIdsRanges = mergedRanges.Select(l => {
                string[] parts = l.Split('-');
                return (long.Parse(parts[0]), long.Parse(parts[1]));
            }).ToList();
            long possibleFreshCount = freshIdsRanges.Sum(f => f.max - f.min + 1);

            Console.WriteLine($"Part Two: Count of possible fresh Ids: {possibleFreshCount}");
        }
    }
}
