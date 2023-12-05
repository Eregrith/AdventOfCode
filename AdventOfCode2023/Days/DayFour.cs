using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2023.GondolaLift;
using AdventOfCode2023.Scratchcards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Days
{
    internal class DayFour
    {
        internal static void PartOne()
        {
            Console.WriteLine("Day four - Part One");
            List<string> input = PuzzleInputHelper.GetInputLines("DayFour.txt");
            List<Scratchcard> cards = input.Select(Scratchcard.FromLine).ToList();

            int sum = cards.Sum(c => c.Score);

            Console.WriteLine($"The sum of points is {sum}");
            Console.WriteLine("Day four - End of part One");
        }

        internal static void PartTwo()
        {
            Console.WriteLine("Day four - Part Two");
            List<string> input = PuzzleInputHelper.GetInputLines("DayFour.txt");
            List<Scratchcard> cards = input.Select(Scratchcard.FromLine).ToList();

            for (int i = 0; i < cards.Count; i++)
            {
                Scratchcard card = cards.ElementAt(i);
                if (card.NumberOfCardsToCopy > 0)
                {
                    int instancesAdded = card.Instances;
                    int copies = card.NumberOfCardsToCopy;
                    while (copies > 0)
                    {
                        cards.ElementAt(i + copies).Instances += instancesAdded;
                        copies--;
                    }
                }
            }

            int sum = cards.Sum(c => c.Instances);

            Console.WriteLine($"The sum of instances is {sum}");
            Console.WriteLine("Day four - End of part Two");
        }
    }
}
