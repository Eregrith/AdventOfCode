using AdventOfCode2019.Mazes;
using AdventOfCode2019.Mazes.Factories;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Tests.Mazes.Factories
{
    [TestFixture]
    class DayEighteenMazeFactoryTests
    {
        [Test]
        public void DayEighteenMazeFactoryTests_Should_BeDerivedFrom_BasicMazeCellFactory()
        {
            typeof(DayEighteenMazeFactory).Should().BeDerivedFrom<BasicMazeFactory>();
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeCorridor_For_Dot()
        {
            IMazeCellFactory factoryTested = new DayEighteenMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   . ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeCorridor>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeEntrance_For_Arobase()
        {
            IMazeCellFactory factoryTested = new DayEighteenMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   @ ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeEntrance>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeKey_For_LowercaseLetter()
        {
            IMazeCellFactory factoryTested = new DayEighteenMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   o ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeKey>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazeKey).Id.Should().Be('o');
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeDoor_For_UppercaseLetter()
        {
            IMazeCellFactory factoryTested = new DayEighteenMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   O ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeDoor>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazeDoor).Id.Should().Be('O');
        }
    }
}
