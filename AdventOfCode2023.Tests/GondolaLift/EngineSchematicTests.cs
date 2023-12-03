using AdventOfCode2023.GondolaLift;
using FluentAssertions;

namespace AdventOfCode2023.Tests.GondolaLift
{
    internal class EngineSchematicTests
    {
        [Test]
        public void FromMatrix_Should_Create_Schematic_From_Char_Matrix()
        {
            char[][] matrix = new[]
            {
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Width.Should().Be(3);
            schematic.Height.Should().Be(4);
        }

        [Test]
        public void FromMatrix_Should_Insert_Matrix_In_Schematic()
        {
            char[][] matrix = new[]
            {
                new[] { '3', '.', '.' },
                new[] { '.', '.', '2' },
                new[] { '.', '1', '.' },
                new[] { '.', '.', '.' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.CharAt(0, 0).Should().Be('3');
            schematic.CharAt(2, 1).Should().Be('2');
            schematic.CharAt(1, 2).Should().Be('1');
        }

        [Test]
        public void EngineSchematic_Should_Contain_A_Part_When_There_Is_One_In_The_Matrix()
        {
            char[][] matrix = new[]
            {
                new[] { '#', '1', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Parts.Should().HaveCount(1);
        }

        [Test]
        public void EngineSchematic_Should_Group_Digits_Into_Part_Numbers()
        {
            char[][] matrix = new[]
            {
                new[] { '#', '1', '2' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Parts.Should().HaveCount(1);
            schematic.Parts[0].Number.Should().Be(12);
        }

        [Test]
        public void EngineSchematic_Should_Only_Recognize_Parts_That_Are_Anchored_To_A_Symbol()
        {
            char[][] matrix = new[]
            {
                new[] { '#', '1', '2' },
                new[] { '.', '.', '.' },
                new[] { '2', '3', '.' },
                new[] { '.', '.', '.' },
                new[] { '&', '6', '3' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Parts.Should().HaveCount(2);
            schematic.Parts[0].Number.Should().Be(12);
            schematic.Parts[1].Number.Should().Be(63);
        }

        [Test]
        public void EngineSchematic_Should_Recognize_Parts_That_Are_Diagonally_Anchored_To_A_Symbol()
        {
            char[][] matrix = new[]
            {
                new[] { '.', '1', '2' },
                new[] { '#', '.', '.' },
                new[] { '.', '3', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '.' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Parts.Should().HaveCount(2);
            schematic.Parts[0].Number.Should().Be(12);
            schematic.Parts[1].Number.Should().Be(3);
        }

        [Test]
        public void EngineSchematic_Should_Recognize_Gears_As_Stars_Adjacent_To_Two_Part_Numbers()
        {
            char[][] matrix = new[]
            {
                new[] { '.', '1', '2' },
                new[] { '*', '.', '.' },
                new[] { '.', '3', '.' },
                new[] { '.', '.', '.' },
                new[] { '.', '.', '*' },
            };

            EngineSchematic schematic = EngineSchematic.FromMatrix(matrix);

            schematic.Gears.Should().HaveCount(1);
            schematic.Gears[0].Ratio.Should().Be(12 * 3);
        }
    }
}
