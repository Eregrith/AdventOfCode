using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day02Tests
{
    [Test]
    public void Part1_Should_Count_Report_Safe_When_Its_Numbers_Are_Going_In_Same_Direction()
    {
        List<string> fakeInput = new List<string>
        {
            "1 2 3 4 5 6",
            "1 2 3 4 5 6",
            "1 2 3 1 2 3",
        };
        string expectedMessage = $"Number of safe reports: 2";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day02.txt")).Returns(fakeInput);
        Day02 day02 = new Day02(puzzleInputHelperMock.Object);
        
        day02.Part1();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Count_Report_Safe_When_Its_Numbers_Are_Not_More_Than_3_Apart()
    {
        List<string> fakeInput = new List<string>
        {
            "1 2 5 8 11 13",
            "1 4 7 10 13 16",
            "20 18 16 14 12 10",
            "1 5 8 12 15 19",
            "19 15 14 13 12 11",
        };
        string expectedMessage = $"Number of safe reports: 3";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day02.txt")).Returns(fakeInput);
        Day02 day02 = new Day02(puzzleInputHelperMock.Object);
        
        day02.Part1();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Count_Report_Unsafe_When_Two_Consecutive_Numbers_Are_Equal()
    {
        List<string> fakeInput = new List<string>
        {
            "1 2 3 4 5 6",
            "1 2 3 4 5 6",
            "1 2 3 4 5 6",
            
            "1 2 2 4 5 6",
            "1 2 3 4 4 6",
        };
        string expectedMessage = $"Number of safe reports: 3";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day02.txt")).Returns(fakeInput);
        Day02 day02 = new Day02(puzzleInputHelperMock.Object);
        
        day02.Part1();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Tolerate_One_Bad_Level_In_Otherwise_Safe_Reports()
    {
        List<string> fakeInput = new List<string>
        {
            "7 6 4 2 1", // safe
            "1 2 7 8 9", // unsafe with 2=>7 and 2=>8
            "9 7 6 2 1", // unsafe with 6=>2 and 6=>1 
            "1 3 2 4 5", 
            "8 6 4 4 1",
            "1 3 6 7 9",
            "1 1 6 7 8",
            "48 46 47 49 51 54 56",
            "1 1 2 3 4 5",
            "1 2 3 4 5 5",
            "5 1 2 3 4 5",
            "1 4 3 2 1",
            "1 6 7 8 9",
            "1 2 3 4 3",
            "9 8 7 6 7"
        };
        string expectedMessage = $"Number of safe reports: 12";
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day02.txt")).Returns(fakeInput);
        Day02 day02 = new Day02(puzzleInputHelperMock.Object);
        
        day02.Part2();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
}