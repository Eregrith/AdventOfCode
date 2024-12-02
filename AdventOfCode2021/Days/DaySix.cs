using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2021.Lanternfish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2021.Days
{
    internal class DaySix
    {
        public static void PartOne()
        {
            Console.WriteLine("DaySix - Part One");
            List<int> lanternFish = PuzzleInputHelper.GetInputLinesStatic("DaySix.txt").First().Split(",").Select(l => int.Parse(l)).ToList();
            Console.WriteLine($"Input has {lanternFish.Count} lanternfish");
            int dayCount = 80;
            for (int day = 0; day < dayCount; day++)
            {
                List<int> nextDay = new List<int>();
                lanternFish.ForEach(l =>
                {
                    if (l == 0)
                    {
                        nextDay.Add(6);
                        nextDay.Add(8);
                    }
                    else
                    {
                        nextDay.Add(l - 1);
                    }
                });
                lanternFish = nextDay.ToList();
            }

            Console.WriteLine($"There are now {lanternFish.Count} lanternfish");
            Console.WriteLine("DaySix - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("DaySix - Part Two");
            List<LanternFishConscripts> lanternFish = PuzzleInputHelper.GetInputLinesStatic("DaySix.txt")
                .First().Split(",").Select(l => int.Parse(l))
                .GroupBy(l => l)
                .Select(l => new LanternFishConscripts { DaysRemaining = l.Key, MemberCount = l.Count() })
                .ToList();
            Console.WriteLine($"Input has {lanternFish.Count} lanternfish");
            int dayCount = 256;
            for (int day = 0; day < dayCount; day++)
            {
                List<LanternFishConscripts> nextDay = new List<LanternFishConscripts>();
                lanternFish.ForEach(l =>
                {
                    if (l.DaysRemaining == 0)
                    {
                        AddMembersWithDays(8, l.MemberCount, nextDay);
                        AddMembersWithDays(6, l.MemberCount, nextDay);
                    }
                    else
                    {
                        AddMembersWithDays(l.DaysRemaining - 1, l.MemberCount, nextDay);
                    }
                });
                lanternFish = nextDay.ToList();
            }

            BigInteger sum = 0;
            sum = lanternFish.Aggregate(sum, (agg, l) => agg + l.MemberCount);
            Console.WriteLine($"There are now {sum} lanternfish");
            Console.WriteLine("DaySix - End of part Two");
        }

        private static void AddMembersWithDays(int days, BigInteger memberCount, List<LanternFishConscripts> nextDay)
        {
            var nextDayFish = nextDay.FirstOrDefault(n => n.DaysRemaining == days);
            if (nextDayFish == null)
            {
                nextDayFish = new LanternFishConscripts
                {
                    DaysRemaining = days,
                    MemberCount = memberCount
                };
                nextDay.Add(nextDayFish);
            }
            else
            {
                nextDayFish.MemberCount += memberCount;
            }
        }
    }
}
