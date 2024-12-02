using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.CamelCards;
using AdventOfCode2023.Scratchcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class DaySeven
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day seven - Part One");
            List<string> input = PuzzleInputHelper.GetInputLinesStatic("DaySeven.txt");
            List<CamelCardsHand> hands = input.Select(CamelCardsHand.FromString).ToList();

            hands.Sort();
            int sum = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                sum += hands[i].Bid * (i + 1);
            }

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day seven - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day seven - Part Two");
            List<string> input = PuzzleInputHelper.GetInputLinesStatic("DaySeven.txt");
            List<CamelCardsHand> hands = input.Select(CamelCardsHand.FromString).ToList();

            hands.Sort(new JokerHandComparison());
            int sum = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                sum += hands[i].Bid * (i + 1);
            }

            Console.WriteLine($"The sum is {sum}");
            Console.WriteLine("Day seven - End of part Two");
        }
    }
}
