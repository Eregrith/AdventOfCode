using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day01Tests
{
    [Test]
    public void Part1_Should_Output_Sum_Of_Differences_Of_Each_Pair_Of_Numbers_In_Order_From_Both_Lists()
    {
        List<string> fakeInput = new List<string>
        {
            "1   5",
            "3   7",
            "2   8",
        };
        int expectedOutput = (5 - 1) + (7 - 2) + (8 - 3);
        string expectedMessage = $"Sum of differences is: {expectedOutput}";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day01.txt")).Returns(fakeInput);
        Day01 day01 = new Day01(puzzleInputHelperMock.Object);
        
        day01.Part1();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }

    [Test]
    public void
        Part2_Should_Calculate_Similarity_Score_By_Multiplying_Numbers_In_Left_With_Number_Of_Occurences_In_Right()
    {
        List<string> fakeInput = new List<string>
        {
            "3   4",
            "4   3",
            "2   5",
            "1   3",
            "3   9",
            "3   3",
        };
        int expectedOutput = 3*3 + 4*1 + 2*0 + 1*0 + 3*3 + 3*3;
        string expectedMessage = $"Similarity score is: {expectedOutput}";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day01.txt")).Returns(fakeInput);
        Day01 day01 = new Day01(puzzleInputHelperMock.Object);
        
        day01.Part2();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
}