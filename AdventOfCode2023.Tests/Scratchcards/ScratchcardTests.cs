using AdventOfCode2023.Scratchcards;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.Scratchcards
{
    internal class ScratchcardTests
    {
        [Test]
        public void FromLine_Should_Get_Winning_Numbers_From_Input()
        {
            string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            Scratchcard card = Scratchcard.FromLine(input);

            card.WinningNumbers.Should().HaveCount(5);
            card.WinningNumbers.Should().Contain(41);
            card.WinningNumbers.Should().Contain(48);
            card.WinningNumbers.Should().Contain(83);
            card.WinningNumbers.Should().Contain(86);
            card.WinningNumbers.Should().Contain(17);
        }

        [Test]
        public void FromLine_Should_Get_My_Numbers_From_Input()
        {
            string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            Scratchcard card = Scratchcard.FromLine(input);

            card.MyNumbers.Should().HaveCount(8);
            card.MyNumbers.Should().Contain(83);
            card.MyNumbers.Should().Contain(86);
            card.MyNumbers.Should().Contain(6);
            card.MyNumbers.Should().Contain(31);
            card.MyNumbers.Should().Contain(17);
            card.MyNumbers.Should().Contain(9);
            card.MyNumbers.Should().Contain(48);
            card.MyNumbers.Should().Contain(53);
        }

        [Test]
        public void Score_Should_Be_Two_To_The_Power_Number_Of_MyNumbers_That_Are_Winning_Minus_One()
        {
            string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            Scratchcard card = Scratchcard.FromLine(input);

            card.Score.Should().Be(8);
        }

        [Test]
        public void NumberOfCardsToCopy_Should_Be_The_Number_Of_MyNumbers_Matching_WinningNumbers()
        {
            string input = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";

            Scratchcard card = Scratchcard.FromLine(input);

            card.NumberOfCardsToCopy.Should().Be(4);
        }
    }
}
