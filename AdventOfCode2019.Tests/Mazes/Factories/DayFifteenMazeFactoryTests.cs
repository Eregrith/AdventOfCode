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
    class DayFifteenMazeFactoryTests
    {
        [Test]
        public void DayFifteenMazeFactory_Should_BeDerivedFrom_BasicMazeFactory()
        {
            typeof(DayFifteenMazeFactory).Should().BeDerivedFrom<BasicMazeFactory>();
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeOxygen_For_o()
        {
            IMazeCellFactory factoryTested = new DayFifteenMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   o ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeOxygen>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazeOxygen).IsActive.Should().BeTrue();
        }
    }
}
