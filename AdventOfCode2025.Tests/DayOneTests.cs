using AdventOfCode.Elves.IOHelpers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025.Tests
{
    internal class DayOneTests
    {
        [TestCase("R19")]
        [TestCase("R29")]
        [TestCase("R39")]
        [TestCase("R49")]
        public void NoHitRotation_Should_Count_0_Hits(string input)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(new List<string> { input });
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be("Part Two: Number of 0 mid-rotation hits 0");
        }

        [TestCase("R50")]
        public void Going_Up_To_100_Should_Count_1_Hit(string input)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(new List<string> { input });
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be("Part Two: Number of 0 mid-rotation hits 1");
        }

        [TestCase("L50")]
        public void Going_Down_To_0_Should_Count_1_Hit(string input)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(new List<string> { input });
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be("Part Two: Number of 0 mid-rotation hits 1");
        }

        [TestCase("R29,R21")]
        public void Going_Up_To_100_In_Two_Moves_Should_Count_1_Hit(string inputLines)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(inputLines.Split(",").ToList());
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be("Part Two: Number of 0 mid-rotation hits 1");
        }

        [TestCase("L29,L21")]
        public void Going_Down_To_0_In_Two_Moves_Should_Count_1_Hit(string inputLines)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(inputLines.Split(",").ToList());
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be("Part Two: Number of 0 mid-rotation hits 1");
        }

        [TestCase("R1000", 10)]
        [TestCase("R50,R200", 3)]
        [TestCase("L50,L200", 3)]
        public void Passing_0_Multiple_Times_In_One_Move_Should_Count_All_Hits(string inputLines, int hits)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(inputLines.Split(",").ToList());
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be($"Part Two: Number of 0 mid-rotation hits {hits}");
        }

        [TestCase("L68,L30,R48,L5,R60,L55,L1,L99,R14,L82", 6)]
        public void Complex_Cases_Should_Be_Handled_Correctly(string inputLines, int hits)
        {
            Mock<IPuzzleInputHelper> mockInputHelper = new Mock<IPuzzleInputHelper>();
            mockInputHelper.Setup(m => m.GetInputLines(It.IsAny<string>())).Returns(inputLines.Split(",").ToList());
            StringBuilder sb = new();
            StringWriter sw = new StringWriter(sb);
            Console.SetOut(sw);

            DayOne dayOne = new DayOne(mockInputHelper.Object);

            dayOne.PartTwo();

            sb.ToString().Trim().Should().Be($"Part Two: Number of 0 mid-rotation hits {hits}");
        }
    }
}
