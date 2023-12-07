using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.CamelCards
{
    internal class CamelCardsHand
    {
        public int Bid { get; set; }
        public int Strength { get; set; }

        public static CamelCardsHand FromString(string input)
        {
            int strength = 0;
            string hand = input.Substring(0, 5);
            List<char> characters = hand.ToList();
            List<(char card, int occurrences)> cards = characters.Distinct().Select(c => (c, characters.Count(ch => ch == c))).ToList();
            strength = cards.Count(c => c.occurrences == 2);
            strength += cards.Count(c => c.occurrences == 3) * 3;
            strength += cards.Count(c => c.occurrences == 4) * 5;
            strength += cards.Count(c => c.occurrences == 5) * 6;
            return new CamelCardsHand
            {
                Strength = strength,
                Bid = int.Parse(input.Substring(6))
            };
        }
    }
}
