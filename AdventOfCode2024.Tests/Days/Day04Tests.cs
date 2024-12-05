using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day04Tests
{
    [Test]
    public void Part1_Should_Output_0_XMAS_When_There_Is_None_In_The_Input()
    {
        List<string> fakeInputLines = new()
        {
            "ABCDEF",
            "ABCDEF",
            "ABCDEF",
            "ABCDEF",
        };
        string expectedMessage = "Number of valid XMAS: 0";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day04.txt")).Returns(fakeInputLines);
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Output_Number_Of_XMAS_In_Left_To_Right_Order_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "XMASEF",
            "AXMASF",
            "ABXMAS",
        };
        string expectedMessage = "Number of valid XMAS: 3";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Output_Number_Of_XMAS_In_Right_To_Left_Order_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "SAMXEF",
            "ASAMXF",
            "ABXMAS",
        };
        string expectedMessage = "Number of valid XMAS: 3";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Output_Number_Of_XMAS_In_Top_To_Bottom_Order_Or_Reverse_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "AXAASAA",
            "AMAAAAA",
            "AAAAMAA",
            "ASAAXAA",
        };
        string expectedMessage = "Number of valid XMAS: 2";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Output_Number_Of_XMAS_In_Diagonals_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "...X......S.",
            "....M....A..",
            ".....A..M...",
            "......SX....",
            ".S.........X",
            "..A.......M.",
            "...M.....A..",
            "....X...S...",
        };
        string expectedMessage = "Number of valid XMAS: 4";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Not_Count_Non_Full_XMAS_Words()
    {
        List<string> fakeInputLines = new()
        {
            "XMASXX",
            "XXMASX",
            "XXXMAS",
        };
        string expectedMessage = "Number of valid XMAS: 3";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Output_0_X_MAS_When_There_Are_None_In_The_Input()
    {
        List<string> fakeInputLines = new()
        {
            "AAAAA",
            "AAAAA",
            "AAAAA",
        };
        string expectedMessage = "Number of valid X-MAS: 0";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Count_X_MAS_Left_To_Right_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "MAS",
            "AAA",
            "MAS",
        };
        string expectedMessage = "Number of valid X-MAS: 1";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Count_X_MAS_Top_To_Bottom_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "MAM",
            "AAA",
            "SAS",
        };
        string expectedMessage = "Number of valid X-MAS: 1";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Count_Mixed_X_MAS_In_Input()
    {
        List<string> fakeInputLines = new()
        {
            "MMMM",
            "AAAM",
            "SSSS",
        };
        string expectedMessage = "Number of valid X-MAS: 2";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Not_Count_MAM_SAS()
    {
        List<string> fakeInputLines = new()
        {
            "MAS",
            "AAA",
            "SAM",
        };
        string expectedMessage = "Number of valid X-MAS: 0";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Match_Example_Answer()
    {
        List<string> fakeInputLines = new()
        {
            ".M.S......",
            "..A..MSMS.",
            ".M.S.MAA..",
            "..A.ASMSM.",
            ".M.S.M....",
            "..........",
            "S.S.S.S.S.",
            ".A.A.A.A..",
            "M.M.M.M.M.",
            "..........",
        };
        string expectedMessage = "Number of valid X-MAS: 9";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new();
        Mock<TextWriter> tw = new();
        Console.SetOut(tw.Object);
        puzzleInputHelperMock.Setup(p => p.GetInputMatrix("Day04.txt")).Returns(fakeInputLines.Select(l => l.ToArray()).ToArray());
        Day04 day04 = new(puzzleInputHelperMock.Object);
        
        day04.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
}