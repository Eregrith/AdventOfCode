using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Scratchcards
{
    internal class Scratchcard
    {
        public List<int> WinningNumbers { get; private set; }
        public List<int> MyNumbers { get; private set; }
        public int Score { get; private set; }
        public int NumberOfCardsToCopy { get; set; }
        public int Instances { get; set; } = 1;

        public static Scratchcard FromLine(string input)
        {
            Scratchcard card = new Scratchcard();

            string[] parts = input.Split("|", StringSplitOptions.TrimEntries);
            string[] subparts = parts[0].Split(":", StringSplitOptions.TrimEntries);
            card.WinningNumbers = subparts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            card.MyNumbers = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> myWinningNumbers = card.MyNumbers.Intersect(card.WinningNumbers).ToList();
            card.NumberOfCardsToCopy = myWinningNumbers.Count;
            card.Score = (int)Math.Pow(2, card.NumberOfCardsToCopy - 1);

            return card;
        }
    }
}
