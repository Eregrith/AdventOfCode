using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day06Tests
{
    [Test]
    public void Part1_Should_Output_Number_Of_Places_Visited_By_Guard_When_He_Goes_Straight_Out()
    {
        char[][] fakeInput =
        [
            ".....".ToArray(),
            ".....".ToArray(),
            "^....".ToArray(),
            ".....".ToArray(),
            ".....".ToArray()
        ];
        
        string expectedMessage = $"Number of different visited places: 3";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day06.txt")).Returns(fakeInput);
        Day06 day06 = new Day06(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day06.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Output_Number_Of_Places_Visited_By_Guard_When_He_Has_To_Turn_Right_Once()
    {
        char[][] fakeInput =
        [
            "#....".ToArray(),
            ".....".ToArray(),
            "^....".ToArray(),
            ".....".ToArray(),
            ".....".ToArray()
        ];
        
        string expectedMessage = $"Number of different visited places: 6";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day06.txt")).Returns(fakeInput);
        Day06 day06 = new Day06(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day06.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Output_Number_Of_Places_Visited_By_Guard_When_He_Has_To_Turn_Right_Twice()
    {
        char[][] fakeInput =
        [
            "#....".ToArray(),
            "....#".ToArray(),
            "^....".ToArray(),
            ".....".ToArray(),
            ".....".ToArray()
        ];
        
        string expectedMessage = $"Number of different visited places: 8";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day06.txt")).Returns(fakeInput);
        Day06 day06 = new Day06(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day06.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Output_Number_Of_Places_Visited_By_Guard_When_He_Has_To_Go_Over_His_Path()
    {
        char[][] fakeInput =
        [
            "#....".ToArray(),
            "....#".ToArray(),
            "^....".ToArray(),
            "...#.".ToArray(),
            ".....".ToArray()
        ];
        
        string expectedMessage = $"Number of different visited places: 8";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day06.txt")).Returns(fakeInput);
        Day06 day06 = new Day06(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day06.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
}