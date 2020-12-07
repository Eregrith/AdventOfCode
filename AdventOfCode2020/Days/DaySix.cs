using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class DaySix
    {
        public static void PartOne()
        {
            Console.WriteLine("Day six - Part One");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatched("DaySix.txt", String.Empty);
            List<string> uniqueAnswers = new List<string>();
            lines.Aggregate(uniqueAnswers, (ua, answers) => {
                ua.Add(String.Join("", String.Join("", answers).Distinct()));
                return ua;
            });
            int sumOfUniqueAnswers = uniqueAnswers.Sum(ua => ua.Length);
            Console.WriteLine($"Unique answers for first group is {uniqueAnswers[0]}");
            Console.WriteLine($"Sum of all groups count is {sumOfUniqueAnswers}");
            Console.WriteLine("Day six - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day six - Part Two");
            List<List<string>> lines = PuzzleInputHelper.GetInputLinesBatched("DaySix.txt", String.Empty);
            List<string> uniqueAnswers = new List<string>();
            lines.Aggregate(uniqueAnswers, (ua, answers) => {
                ua.Add(String.Join("", String.Join("", answers).Distinct()));
                return ua;
            });
            int sum = lines.Zip(uniqueAnswers, (answers, ua) => ua.Count(c => String.Join("", answers).Count(a => a == c) == answers.Count)).Sum();
            Console.WriteLine($"Sum of all groups count is {sum}");
            Console.WriteLine("Day six - End of Part Two");
        }
    }
}
