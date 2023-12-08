using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.CamelCards
{
    internal class JokerHandComparison : Comparer<CamelCardsHand>
    {
        private const string OrderOfCardWithJokers = "J23456789TQKA";

        public override int Compare(CamelCardsHand? x, CamelCardsHand? y)
        {
            if (x == null || y == null) return 0;

            int strengthDiff = x.StrengthWithJokers - y.StrengthWithJokers;
            if (strengthDiff != 0) return strengthDiff;

            for (int c = 0; c < 5; c++)
            {
                char cardOne = x.Cards[c];
                char cardTwo = y.Cards[c];

                if (cardOne != cardTwo)
                {
                    return OrderOfCardWithJokers.IndexOf(cardOne) - OrderOfCardWithJokers.IndexOf(cardTwo);
                }
            }
            return 0;
        }
    }
}
