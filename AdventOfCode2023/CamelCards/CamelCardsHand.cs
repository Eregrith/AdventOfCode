using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.CamelCards
{
    internal class CamelCardsHand : IComparable
    {
        public enum HandStrength
        {
            HighCard,
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind,
        }
        public int Bid { get; set; }
        public HandStrength Strength { get; set; }
        public string Cards { get; set; }
        public HandStrength StrengthWithJokers { get; set; }

        private const string OrderOfCards = "23456789TJQKA";

        public static CamelCardsHand FromString(string input)
        {
            string hand = input.Substring(0, 5);
            List<char> characters = hand.ToList();
            List<(char card, int occurrences)> cards = characters.Distinct().Select(c => (c, characters.Count(ch => ch == c))).ToList();
            int strength = cards.Count(c => c.occurrences == 2);
            strength += cards.Count(c => c.occurrences == 3) * 3;
            strength += cards.Count(c => c.occurrences == 4) * 5;
            strength += cards.Count(c => c.occurrences == 5) * 6;
            int strengthWithJokers = ComputeStrengthWithJokers(characters);
            return new CamelCardsHand
            {
                Cards = hand,
                Strength = (HandStrength)strength,
                StrengthWithJokers = (HandStrength)strengthWithJokers,
                Bid = int.Parse(input.Substring(6))
            };
        }

        private static int ComputeStrengthWithJokers(List<char> characters)
        {
            List<(char card, int occurrences)> cardsWithJokersCounted = characters.Distinct().Select(c => (c, characters.Count(ch => ch == 'J' || ch == c))).ToList();
            int numberOfJokers = characters.Count(c => c == 'J');
            int cardsOccurringThrice = cardsWithJokersCounted.Count(c => c.occurrences == 3);
            int cardsOccurringTwice = cardsWithJokersCounted.Count(c => c.occurrences == 2);
            int strength = cardsOccurringTwice;
            if (numberOfJokers >= 1)
                strength = 1;
            if (cardsOccurringThrice is 1 or 3)
            {
                strength = 3;
            }

            if (cardsOccurringThrice == 2 || cardsOccurringThrice == 1 && cardsOccurringTwice == 1)
            {
                strength = 4;
            }

            if (cardsWithJokersCounted.Count(c => c.occurrences == 4) >= 1)
            {
                strength = 5;
            }
            if (cardsWithJokersCounted.Count(c => c.occurrences == 5) == 1)
            {
                strength = 6;
            }
            return strength;
        }

        public int CompareTo(object? obj)
        {
            if (obj is CamelCardsHand otherHand)
            {
                int strengthDiff = Strength - otherHand.Strength;
                if (strengthDiff != 0) return strengthDiff;

                for (int c = 0; c < 5; c++)
                {
                    char cardOne = Cards[c];
                    char cardTwo = otherHand.Cards[c];

                    if (cardOne != cardTwo)
                    {
                        return OrderOfCards.IndexOf(cardOne) - OrderOfCards.IndexOf(cardTwo);
                    }
                }
            };
            return 0;
        }
    }
}