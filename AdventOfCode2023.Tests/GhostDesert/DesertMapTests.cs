using AdventOfCode2023.GhostDesert;
using FluentAssertions;

namespace AdventOfCode2023.Tests.GhostDesert
{
    internal class DesertMapTests
    {
        [Test]
        public void ParseMap_Should_Return_DesertMap_From_Input_Lines()
        {
            List<string> lines = new()
            {
                "R",
                "",
                "AAA = (BBB, BBB)"
            };

            DesertMap map = DesertMap.ParseMap(lines);

            map.Should().NotBeNull();
        }

        [Test]
        public void CountStepsTo_Should_Return_Zero_When_Target_Is_Current_Node()
        {
            List<string> lines = new()
            {
                "R",
                "",
                "AAA = (BBB, BBB)"
            };

            DesertMap map = DesertMap.ParseMap(lines);

            map.CountStepsTo("AAA").Should().Be(0);
        }

        [Test]
        public void CountStepsTo_Should_Return_One_When_Target_Is_Next_In_Order()
        {
            List<string> lines = new()
            {
                "R",
                "",
                "AAA = (BBB, BBB)"
            };

            DesertMap map = DesertMap.ParseMap(lines);

            map.CountStepsTo("BBB").Should().Be(1);
        }

        [Test]
        public void CountStepsTo_Should_Return_Steps_Count_When_Target_Is_Further_Away()
        {
            List<string> lines = new()
            {
                "LLR",
                "",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)",
            };

            DesertMap map = DesertMap.ParseMap(lines);

            map.CountStepsTo("ZZZ").Should().Be(6);
        }

        [Test]
        public void CountGhostStepsTo_Should_Return_Steps_Count_To_Reach_Target_Simultaneously()
        {
            List<string> lines = new()
            {
                "LR",
                "",
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)",
            };

            DesertMap map = DesertMap.ParseMap(lines);

            map.CountGhostStepsTo("Z").Should().Be(6);
        }
    }
}
