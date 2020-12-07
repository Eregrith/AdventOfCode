using AdventOfCode.Elves.IOHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2020.Days
{
    public class BagRule
    {
        public string Color { get; private set; }
        public List<(int amount, string color)> ContainmentRules { get; } = new List<(int amount, string color)>();

        public static BagRule FromLine(string line)
        {
            string[] parts = line.Split(new[] { "bags contain" }, StringSplitOptions.None);
            BagRule bagRule = new BagRule();
            bagRule.Color = parts[0].Trim();

            string[] contents = parts[1].Split(',');

            foreach (string contentRule in contents)
            {
                Regex r = new Regex(@"(?<amount>[0-9]+) (?<color>.+) bags?");
                Match m = r.Match(contentRule);
                if (m.Success)
                {
                    bagRule.ContainmentRules.Add((Int32.Parse(m.Groups["amount"].Value), m.Groups["color"].Value));
                }
            }

            return bagRule;
        }

        public bool CanContain(string color)
        {
            return ContainmentRules.Any(br => br.color == color);
        }

        public override string ToString()
        {
            return $"A [{Color}] bag can contain:{Environment.NewLine + "- "}{String.Join(Environment.NewLine + "- ", ContainmentRules.Select(br => "[" + br.amount + "] of {" + br.color + "}"))}";
        }

        public IEnumerable<int> BagsInside(List<BagRule> rules)
        {
            foreach ((int a, string c) in ContainmentRules)
            {
                BagRule subBag = rules.First(r => r.Color == c);
                yield return a * (subBag.BagsInside(rules).Sum() + 1);
            }
        }
    }

    public class DaySeven
    {
        public static void PartOne()
        {
            Console.WriteLine("Day seven - Part One");
            List<BagRule> rules = PuzzleInputHelper.GetInputLines("DaySeven.txt")
                .Select(BagRule.FromLine)
                .ToList();
            Console.WriteLine($"There are {rules.Count} rules");
            List<string> countedBags = new List<string>();
            Queue<string> bagsToCheck = new Queue<string>();
            bagsToCheck.Enqueue("shiny gold");

            while (bagsToCheck.Count > 0)
            {
                string currentBagToCheck = bagsToCheck.Dequeue();
                countedBags.Add(currentBagToCheck);
                var bagsAroundCurrent = rules.Where(br => br.CanContain(currentBagToCheck)).ToList();
                bagsAroundCurrent.ForEach(bag => { if (!countedBags.Contains(bag.Color) && !bagsToCheck.Contains(bag.Color)) bagsToCheck.Enqueue(bag.Color); });
            }
            Console.WriteLine($"There were {countedBags.Count} counted bags");
            Console.WriteLine("Day seven - End of part One");
        }

        public static void PartTwo()
        {
            Console.WriteLine("Day seven - Part Two");
            List<BagRule> rules = PuzzleInputHelper.GetInputLines("DaySeven.txt")
                .Select(BagRule.FromLine)
                .ToList();

            int sumOfBags = rules.First(br => br.Color == "shiny gold").BagsInside(rules).Sum();
            Console.WriteLine($"A shiny gold bag will contain {sumOfBags} bags in it");
            Console.WriteLine("Day seven - End of Part Two");
        }
    }
}
