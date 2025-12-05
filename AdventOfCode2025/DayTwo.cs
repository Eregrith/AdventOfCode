using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{
    public interface IIDValidityChecker
    {
        bool Check(string id);
    }

    internal class IDValidityChecker : IIDValidityChecker
    {
        public bool Check(string id)
        {
            string left = id.Substring(0, id.Length / 2);
            string right = id.Substring(id.Length / 2);
            return left != right;
        }
    }

    internal class SpecialIDValidityChecker : IIDValidityChecker
    {
        public bool Check(string id)
        {
            int size = id.Length / 2;
            while (size > 0)
            {
                List<string> parts = SplitInPartsOfSize(id, size);
                if (parts.Distinct().Count() == 1) return false;
                size--;
            }
            return true;
        }

        private List<string> SplitInPartsOfSize(string id, int size)
        {
            List<string> parts = new List<string>();
            if (id.Length % size != 0) return parts;
            for (int i = 0; i < id.Length; i += size)
            {
                parts.Add(id.Substring(i, size));
            }
            return parts;
        }
    }

    internal class IDCrawler(IIDValidityChecker checker)
    {
        internal List<long> Crawl(string idRange)
        {
            string[] parts = idRange.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            List<long> invalidIds = new List<long>();
            for (long i = start; i <= end; i++)
            {
                string id = i.ToString();
                if (!checker.Check(id))
                {
                    invalidIds.Add(i);
                }
            }
            return invalidIds;
        }
    }

    internal class DayTwo(IPuzzleInputHelper inputHelper)
    {
        public void PartOne()
        {
            List<String> lines = inputHelper.GetInputLines("DayTwo.txt")[0].Split(",").ToList();
            long sum = 0;
            var crawler = new IDCrawler(new IDValidityChecker());

            foreach (string line in lines)
            {
                var invalidIds = crawler.Crawl(line);
                sum += invalidIds.Sum();
            }

            Console.WriteLine($"Part One: Sum of invalid IDs: {sum}");
        }
        public void PartTwo()
        {
            List<String> lines = inputHelper.GetInputLines("DayTwo.txt")[0].Split(",").ToList();
            long sum = 0;
            var crawler = new IDCrawler(new SpecialIDValidityChecker());

            foreach (string line in lines)
            {
                var invalidIds = crawler.Crawl(line);
                sum += invalidIds.Sum();
            }

            Console.WriteLine($"Part Two: Sum of invalid IDs: {sum}");
        }
    }
}
