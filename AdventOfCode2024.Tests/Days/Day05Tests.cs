using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day05Tests
{
    [TestCase("1,2,3")]
    [TestCase("0,1,2,3,4")]
    [TestCase("2")]
    public void Part1_Should_Output_Middle_Page_Number_When_The_Pages_Are_In_Order(string printOrder)
    {
        List<List<string>> fakeInput =
        [
            [ "1|2" ],
            [ printOrder ]
        ];
        string expectedMessage = $"Sum of valid rules middle numbers: 2";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Output_Sum_Of_Middle_Page_Numbers_When_Multiple_PrintOrder_Lines_Are_In_Order()
    {
        List<List<string>> fakeInput =
        [
            [ "1|2" ],
            [
                "1,2,3",
                "0,1,6,3,4"
            ]
        ];
        string expectedMessage = $"Sum of valid rules middle numbers: 8";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Not_Sum_Middle_Page_Numbers_When_Page_Appears_In_Wrong_Order()
    {
        List<List<string>> fakeInput =
        [
            [ "2|1" ],
            [
                "2,1,3",
                "0,1,2,6,3"
            ]
        ];
        string expectedMessage = $"Sum of valid rules middle numbers: 1";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part1_Should_Handle_Example_Case()
    {
        List<List<string>> fakeInput =
        [
            [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13"
            ],
            [
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            ]
        ];
        string expectedMessage = $"Sum of valid rules middle numbers: 143";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part1();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Reorder_Incorrectly_Ordered_Prints_And_Output_Sum_Of_Their_Middle_Page()
    {
        List<List<string>> fakeInput =
        [
            [ "2|1" ],
            [
                "2,1,3",
                "0,1,2,8,4,6,3"
            ]
        ];
        string expectedMessage = $"Sum of updated invalid rules middle numbers: 8";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
    
    [Test]
    public void Part2_Should_Handle_The_Example()
    {
        List<List<string>> fakeInput =
        [
            [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13"
            ],
            [
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            ]
        ];
        string expectedMessage = $"Sum of updated invalid rules middle numbers: 123";
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLinesBatched("Day05.txt", String.Empty)).Returns(fakeInput);
        Day05 day05 = new Day05(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        
        day05.Part2();
        
        tw.Verify(t => t.WriteLine(expectedMessage), Times.Once);
    }
}