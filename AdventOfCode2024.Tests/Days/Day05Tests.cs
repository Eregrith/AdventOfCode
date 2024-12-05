using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day05Tests
{
    [Test]
    public void Part1_Should_Output_Middle_Rule_Number_When_The_Rules_Are_In_Order()
    {
        List<string> fakeInput = new List<string>
        {
            "1|2",
            "",
            "1,2,3"
        };
        string expectedMessage = $"Sum of valid rules middle numbers: 2";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day05.txt")).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
}