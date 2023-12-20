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

        [Test]
        public void Matrix_Should_Declare_Ground_Tiles_On_Ground()
        {
            char[][] input = new[]
            {
                new[] { 'S', '7', '.' },
                new[] { 'L', 'J', '.' },
                new[] { '.', '.', '.' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            loop.At(2, 0).Type.Should().Be('.');
            loop.At(2, 1).Type.Should().Be('.');

            loop.At(0, 2).Type.Should().Be('.');
            loop.At(1, 2).Type.Should().Be('.');
            loop.At(2, 2).Type.Should().Be('.');
        }

        [Test]
        public void Matrix_Should_Declare_Ground_Tiles_On_Unconnected_Pipes()
        {
            char[][] input = new[]
            {
                new[] { 'S', '7', '-' },
                new[] { 'L', 'J', '|' },
                new[] { '|', 'L', 'J' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            loop.At(2, 0).Type.Should().Be('.');
            loop.At(2, 1).Type.Should().Be('.');

            loop.At(0, 2).Type.Should().Be('.');
            loop.At(1, 2).Type.Should().Be('.');
            loop.At(2, 2).Type.Should().Be('.');
        }

        [Test]
        public void Matrix_Should_Declare_Ground_Tiles_Outside_When_They_Are_Next_To_The_Border()
        {
            Assert.Inconclusive();
            char[][] input = new[]
            {
                new[] { '.', '.', '.', '.' },
                new[] { '.', 'S', '7', '-' },
                new[] { '.', 'L', 'J', '|' },
                new[] { '.', '|', 'L', 'J' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            (loop.At(0, 0) as Ground).Position.Should().Be('O');
            (loop.At(1, 0) as Ground).Position.Should().Be('O');
            (loop.At(2, 0) as Ground).Position.Should().Be('O');
            (loop.At(3, 0) as Ground).Position.Should().Be('O');

            (loop.At(0, 1) as Ground).Position.Should().Be('O');
            (loop.At(3, 1) as Ground).Position.Should().Be('O');

            (loop.At(0, 2) as Ground).Position.Should().Be('O');
            (loop.At(3, 2) as Ground).Position.Should().Be('O');

            (loop.At(0, 3) as Ground).Position.Should().Be('O');
            (loop.At(1, 3) as Ground).Position.Should().Be('O');
            (loop.At(2, 3) as Ground).Position.Should().Be('O');
            (loop.At(3, 3) as Ground).Position.Should().Be('O');
        }

        [Test]
        public void Matrix_Should_Declare_Ground_Tiles_Inside_When_They_Are_Reachable_Through_One_Pipe()
        {
            Assert.Inconclusive();
            char[][] input = new[]
            {
                new[] { '.', '.', '.', '.', '.' },
                new[] { '.', 'S', '-', '7', '.' },
                new[] { '.', '|', '.', '|', '.' },
                new[] { '.', 'L', '-', 'J', '.' },
                new[] { '.', '.', '.', '.', '.' },
            };

            PipeLoopMatrix loop = PipeLoopMatrix.FromInput(input);

            loop.Should().NotBeNull();
            (loop.At(2, 2) as Ground).Position.Should().Be('I');
        }
    }
}
