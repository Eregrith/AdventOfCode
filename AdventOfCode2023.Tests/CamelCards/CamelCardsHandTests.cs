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
            hand.Strength.Should().Be(1);
        }

        [TestCase("12321")]
        public void CamelCardHand_Should_Recognize_Two_Pair_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(2);
        }

        [TestCase("11123")]
        [TestCase("12131")]
        public void CamelCardHand_Should_Recognize_Three_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(3);
        }

        [TestCase("11122")]
        public void CamelCardHand_Should_Recognize_Full_House_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(4);
        }

        [TestCase("11112")]
        public void CamelCardHand_Should_Recognize_Four_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(5);
        }

        [TestCase("11111")]
        public void CamelCardHand_Should_Recognize_Five_Of_A_Kind_Strength(string cards)
        {
            string input = $"{cards} 123";

            CamelCardsHand hand = CamelCardsHand.FromString(input);

            hand.Should().NotBeNull();
            hand.Strength.Should().Be(6);
        }
    }
}
