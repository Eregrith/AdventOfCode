using AdventOfCode2023.CamelCards;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.CamelCards
{
    internal class CamelCardsHandTests
    {
        [Test]
        public void FromString_Should_Create_A_CamelCardHand_With_Correct_Bid_From_Input()
        {
            string input = "12345 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Bid.Should().Be(123);
        }

        [Test]
        public void CamelCardHand_Should_Recognize_High_Card_Strength()
        {
            string input = "12345 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Bid.Should().Be(123);
            hand.Strength.Should().Be(0);
        }

        [TestCase("12341")]
        [TestCase("12342")]
        [TestCase("12343")]
        [TestCase("12344")]
        [TestCase("15354")]
        public void CamelCardHand_Should_Recognize_One_Pair_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.OnePair);
        }

        [TestCase("12321")]
        public void CamelCardHand_Should_Recognize_Two_Pair_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.TwoPairs);
        }

        [TestCase("11123")]
        [TestCase("12131")]
        public void CamelCardHand_Should_Recognize_Three_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.ThreeOfAKind);
        }

        [TestCase("11122")]
        public void CamelCardHand_Should_Recognize_Full_House_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.FullHouse);
        }

        [TestCase("11112")]
        public void CamelCardHand_Should_Recognize_Four_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.FourOfAKind);
        }

        [TestCase("11111")]
        public void CamelCardHand_Should_Recognize_Five_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(CamelCardsHand.HandStrength.FiveOfAKind);
        }

        [Test]
        public void CamelCardHand_Should_Be_Sortable_By_Strength()
        {
            CamelCardsHand highCard = CamelCardsHand.FromString("12345 1");
            CamelCardsHand onePair = CamelCardsHand.FromString("11234 1");
            CamelCardsHand twoPairs = CamelCardsHand.FromString("11224 1");
            CamelCardsHand threeOfAKind = CamelCardsHand.FromString("13222 1");
            CamelCardsHand fullHouse = CamelCardsHand.FromString("11122 1");
            CamelCardsHand fourOfAKind = CamelCardsHand.FromString("11114 1");
            CamelCardsHand fiveOfAKind = CamelCardsHand.FromString("11111 1");
            List<CamelCardsHand> expectedSortedHands = new()
            {
                highCard,
                onePair,
                twoPairs,
                threeOfAKind,
                fullHouse,
                fourOfAKind,
                fiveOfAKind,
            };
            List<CamelCardsHand> unsortedHands = new()
            {
                fourOfAKind,
                fullHouse,
                fiveOfAKind,
                threeOfAKind,
                highCard,
                twoPairs,
                onePair,
            };

            unsortedHands.Sort();

            unsortedHands.Should().ContainInConsecutiveOrder(expectedSortedHands);
        }

        [Test]
        public void CamelCardHand_Should_Be_Sortable_By_HighCard_When_Strength_Is_Same()
        {
            CamelCardsHand onePair = CamelCardsHand.FromString("22345 1");
            CamelCardsHand onePairButBetter = CamelCardsHand.FromString("32245 1");
            CamelCardsHand twoPairs = CamelCardsHand.FromString("22334 1");
            CamelCardsHand twoPairsButBetter = CamelCardsHand.FromString("52233 1");
            List<CamelCardsHand> expectedSortedHands = new()
            {
                onePair,
                onePairButBetter,
                twoPairs,
                twoPairsButBetter,
            };
            List<CamelCardsHand> unsortedHands = new()
            {
                twoPairsButBetter,
                twoPairs,
                onePair,
                onePairButBetter,
            };

            unsortedHands.Sort();

            unsortedHands.Should().ContainInConsecutiveOrder(expectedSortedHands);
        }

        [TestCase("64882")]
        [TestCase("1J234")]
        [TestCase("12J34")]
        [TestCase("123J4")]
        [TestCase("1234J")]
        public void CamelCardHand_Should_Recognize_One_Pair_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.OnePair);
        }

        [TestCase("12241")]
        public void CamelCardHand_Should_Recognize_Two_Pairs_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.TwoPairs);
        }

        [TestCase("11134")]
        [TestCase("1J134")]
        [TestCase("1JJ34")]
        public void CamelCardHand_Should_Recognize_Three_Of_A_Kind_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.ThreeOfAKind);
        }

        [TestCase("11133")]
        [TestCase("1J133")]
        public void CamelCardHand_Should_Recognize_Full_House_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.FullHouse);
        }

        [TestCase("1J113")]
        [TestCase("11113")]
        [TestCase("1JJ33")]
        [TestCase("1JJJ3")]
        public void CamelCardHand_Should_Recognize_Four_Of_A_Kind_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.FourOfAKind);
        }

        [TestCase("11111")]
        [TestCase("1J111")]
        [TestCase("1JJ11")]
        [TestCase("1JJJ1")]
        [TestCase("JJJJ1")]
        [TestCase("JJJJJ")]
        public void CamelCardHand_Should_Recognize_Five_Of_A_Kind_StrengthWithJokers(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.StrengthWithJokers.Should().Be(CamelCardsHand.HandStrength.FiveOfAKind);
        }

        [Test]
        public void CamelCardHand_Should_Be_Sortable_By_Strength_When_Counting_J_As_Jokers()
        {
            CamelCardsHand onePair = CamelCardsHand.FromString("32T3K 1");
            CamelCardsHand twoPairs = CamelCardsHand.FromString("KK677 1");
            CamelCardsHand fourOfAKindOne = CamelCardsHand.FromString("T55J5 1");
            CamelCardsHand fourOfAKindTwo = CamelCardsHand.FromString("QQQJA 1");
            CamelCardsHand fourOfAKindThree = CamelCardsHand.FromString("KTJJT 1");
            List<CamelCardsHand> expectedSortedHands = new()
            {
                onePair,
                twoPairs,
                fourOfAKindOne,
                fourOfAKindTwo,
                fourOfAKindThree
            };
            List<CamelCardsHand> unsortedHands = new()
            {
                fourOfAKindThree,
                twoPairs,
                fourOfAKindOne,
                onePair,
                fourOfAKindTwo
            };

            unsortedHands.Sort(new JokerHandComparison());

            unsortedHands.Should().ContainInConsecutiveOrder(expectedSortedHands);
        }
    }
}
