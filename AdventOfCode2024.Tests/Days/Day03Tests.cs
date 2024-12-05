using AdventOfCode.Elves.IOHelpers;
using AdventOfCode2024.Days;
using Moq;

namespace AdventOfCode2024.Tests.Days;

public class Day03Tests
{
    [TestCase("_", 0, TestName = "No mul() in input should return 0")]
    [TestCase("mul(2,4)", 8, TestName = "mul(2, 4) should return 8")]
    [TestCase("mul(2,4) mul(4,6)", 32, TestName = "Two muls with mul(2, 4) and mul(4,6) should return 32")]
    [TestCase("mul(1, 2)", 0, TestName = "invalid mul(1, 2) should not be counted")]
    [TestCase("do_not_mul(6,2)", 12, TestName = "valid do_not_mul(6,2) should be 12")]
    [TestCase("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", 161, TestName = "Case from the example should work")]
    public void Part1_Should_Output_Sum_Of_Uncorrupted_Mult_Operations(string fakeInput, int expectedSum)
    {
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day03.txt")).Returns(new List<string> { fakeInput });
        Day03 day03 = new Day03(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        string expectedMessage = $"Sum of uncorrupted mult operations is: {expectedSum}";

        day03.Part1();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }

    [TestCase("don't()mul(2,5)", 0, TestName = "don't() disables mul() operations, should be 0")]
    [TestCase("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))", 48, TestName = "Case from the example should work")]
    [TestCase("don't()mul(2,5)\nmul(2,5)", 0, TestName = "don't() should carry over next line")]
    public void Part2_Should_Output_Sum_Of_Active_Uncorrupted_Mult_Operations(string fakeInput, int expectedSum)
    {
        Mock<IPuzzleInputHelper> puzzleInputHelperMock = new Mock<IPuzzleInputHelper>();
        puzzleInputHelperMock.Setup(p => p.GetInputLines("Day03.txt")).Returns(fakeInput.Split("\n").ToList());
        Day03 day03 = new Day03(puzzleInputHelperMock.Object);
        Mock<TextWriter> tw = new Mock<TextWriter>();
        Console.SetOut(tw.Object);
        string expectedMessage = $"Sum of active uncorrupted mult operations is: {expectedSum}";

        day03.Part2();
        
        tw.Verify(c => c.WriteLine(expectedMessage), Times.Once);
    }
}