using AdventOfCode2023.ColoredCubesGame;
using FluentAssertions;

namespace AdventOfCode2023.Tests.ColoredCubesGame
{
    internal class GameLineTests
    {
        [Test]
        public void ToGameLine_Should_Parse_Input_To_Create_GameLine_With_Correct_Id()
        {
            string input = "Game 12: 1 blue";

            GameLine result = GameLine.ToGameLine(input);

            result.Id.Should().Be(12);
        }

        [Test]
        public void ToGameLine_Should_Parse_Input_To_Create_GameLine_With_One_Sequence_When_There_Was_Only_One_Draw()
        {
            string input = "Game 12: 1 blue";

            GameLine result = GameLine.ToGameLine(input);

            result.Sequences.Should().HaveCount(1);
        }

        [Test]
        public void ToGameLine_Should_Parse_Input_To_Create_GameLine_With_Two_Sequences_When_There_Was_Two_Draws()
        {
            string input = "Game 12: 1 blue; 1 red";

            GameLine result = GameLine.ToGameLine(input);

            result.Sequences.Should().HaveCount(2);
        }

        [Test]
        public void ToGameLine_Should_Fill_Sequences_With_The_Numbers_Of_Cubes_For_Each_Color_In_That_Sequence()
        {
            string input = "Game 12: 1 blue; 2 red; 3 green";

            GameLine result = GameLine.ToGameLine(input);

            result.Sequences.Should().HaveCount(3);
            result.Sequences[0].Reds.Should().Be(0);
            result.Sequences[0].Greens.Should().Be(0);
            result.Sequences[0].Blues.Should().Be(1);
            result.Sequences[1].Reds.Should().Be(2);
            result.Sequences[1].Greens.Should().Be(0);
            result.Sequences[1].Blues.Should().Be(0);
            result.Sequences[2].Reds.Should().Be(0);
            result.Sequences[2].Greens.Should().Be(3);
            result.Sequences[2].Blues.Should().Be(0);
        }

        [Test]
        public void ToGameLine_Should_Be_Able_To_Handle_A_Draw_With_Multiple_Cubes()
        {
            string input = "Game 12: 1 blue, 2 red, 3 green";

            GameLine result = GameLine.ToGameLine(input);

            result.Sequences.Should().HaveCount(1);
            result.Sequences[0].Reds.Should().Be(2);
            result.Sequences[0].Greens.Should().Be(3);
            result.Sequences[0].Blues.Should().Be(1);
        }

        [Test]
        public void ToGameLine_Should_Be_Able_To_Handle_A_Draw_With_Multiple_Cubes_And_Multiple_Sequences()
        {
            string input = "Game 12: 1 blue, 2 red, 3 green; 2 blue, 5 green, 1 red";

            GameLine result = GameLine.ToGameLine(input);

            result.Sequences.Should().HaveCount(2);
            result.Sequences[0].Reds.Should().Be(2);
            result.Sequences[0].Greens.Should().Be(3);
            result.Sequences[0].Blues.Should().Be(1);
            result.Sequences[1].Reds.Should().Be(1);
            result.Sequences[1].Greens.Should().Be(5);
            result.Sequences[1].Blues.Should().Be(2);
        }

        [Test]
        public void IsValid_Should_Return_True_When_All_Sequences_Are_Compliant_With_Limits()
        {
            GameLine testedGameLine = GameLine.ToGameLine("Game 12: 1 blue, 2 red, 3 green; 2 blue, 5 green, 1 red");
            CubeLimits limits = new CubeLimits
            {
                Red = 12,
                Green = 13,
                Blue = 14,
            };

            bool result = testedGameLine.IsValid(limits);

            result.Should().BeTrue();
        }

        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 4 red")]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red")]
        [TestCase("Game 13: 8 green, 6 blue, 3 red; 5 blue, 4 red, 14 green; 5 green, 1 red")]
        public void IsValid_Should_Return_False_When_Any_Sequences_Is_NonCompliant_With_Limits(string input)
        {
            GameLine testedGameLine = GameLine.ToGameLine(input);
            CubeLimits limits = new CubeLimits
            {
                Red = 12,
                Green = 13,
                Blue = 14,
            };

            bool result = testedGameLine.IsValid(limits);

            result.Should().BeFalse();
        }

        [Test]
        public void Power_Should_Be_Red_Times_Green_Times_Blue_In_A_One_Sequence_Game()
        {
            GameLine testedGameLine = GameLine.ToGameLine("Game 12: 2 blue, 3 red, 4 green");

            testedGameLine.Power.Should().Be(24);
        }

        [Test]
        public void Power_Should_Use_Lowest_Possible_Amount_Of_Cubes_Of_Each_Color_In_A_Multiple_Sequence_Game()
        {
            GameLine testedGameLine = GameLine.ToGameLine("Game 12: 2 blue, 16 red, 41 green; 12 blue, 3 red, 59 green; 7 blue, 23 red, 4 green");

            testedGameLine.Power.Should().Be(23 * 59 * 12);
        }
    }
}
