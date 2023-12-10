using AdventOfCode2023.OASIS;
using FluentAssertions;

namespace AdventOfCode2023.Tests.OASIS
{
    internal class OasisHistoryReportTests
    {
        [Test]
        public void FromInput_Should_Parse_OasisHistory()
        {
            string input = "1 2 3 4 5";

            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.Values.Should().HaveCount(5);
            report.Values.Should().ContainInOrder(new[] { 1, 2, 3, 4, 5 });
        }

        [Test]
        public void NextValue_Should_Return_Same_Value_When_There_Is_No_Change()
        {
            string input = "1 1 1 1 1";

            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.NextValue.Should().Be(1);
        }

        [Test]
        public void NextValue_Should_Return_Changed_Value_When_There_Is_A_Stable_Change()
        {
            string input = "1 2 3 4 5";

            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.NextValue.Should().Be(6);
        }

        [TestCase("1 2 4 7 11", 16)]
        [TestCase("1 3 6 10 15 21", 28)]
        public void NextValue_Should_Return_Changed_Value_When_There_Is_An_Unstable_Change(string input, int nextValue)
        {
            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.NextValue.Should().Be(nextValue);
        }

        [Test]
        public void PreviousValue_Should_Return_Same_Value_When_There_Is_No_Change()
        {
            string input = "1 1 1 1 1";

            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.PreviousValue.Should().Be(1);
        }

        [Test]
        public void PreviousValue_Should_Return_Changed_Value_When_There_Is_A_Stable_Change()
        {
            string input = "2 3 4 5 6";

            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.PreviousValue.Should().Be(1);
        }

        [TestCase("10 13 16 21 30 45", 5)]
        public void PreviousValue_Should_Return_Changed_Value_When_There_Is_An_Unstable_Change(string input, int previousValue)
        {
            OasisHistoryReport report = OasisHistoryReport.FromInput(input);

            report.PreviousValue.Should().Be(previousValue);
        }
    }
}
