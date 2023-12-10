using AdventOfCode2023.PipeLoops;
using FluentAssertions;

namespace AdventOfCode2023.Tests.PipeLoops
{
    internal class PipeLoopMatrixTests
    {
        [Test]
        public void FromInput_Should_Return_PipeLoopMatrix_With_Calculated_Distances()
        {
            char[][] input = new[]
            {
                new[] { 'S', '7' },
                new[] { 'L', 'J' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            loop.At(0, 0).Distance.Should().Be(0);
            loop.At(1, 0).Distance.Should().Be(1);
            loop.At(0, 1).Distance.Should().Be(1);
            loop.At(1, 1).Distance.Should().Be(2);
        }

        [Test]
        public void Distance_Calculations_Should_Follow_Pipes()
        {
            char[][] input = new[]
            {
                new[] { 'S', '7', 'F', '7' },
                new[] { '|', 'L', 'J', '|' },
                new[] { 'L', '-', '-', 'J' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            loop.At(0, 0).Distance.Should().Be(0);

            loop.At(1, 0).Distance.Should().Be(1);
            loop.At(1, 1).Distance.Should().Be(2);
            loop.At(2, 1).Distance.Should().Be(3);
            loop.At(2, 0).Distance.Should().Be(4);
            loop.At(3, 0).Distance.Should().Be(5);

            loop.At(0, 1).Distance.Should().Be(1);
            loop.At(0, 2).Distance.Should().Be(2);
            loop.At(1, 2).Distance.Should().Be(3);
            loop.At(2, 2).Distance.Should().Be(4);
            loop.At(3, 2).Distance.Should().Be(5);

            loop.At(3, 1).Distance.Should().Be(6);
        }
    }
}
