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
    class BasicMazeFactoryTests
    {
        [Test]
        public void BasicMazeFactory_Should_Implement_IMazeCellFactory()
        {
            typeof(BasicMazeFactory).Should().Implement<IMazeCellFactory>();
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeWall_For_Hashtag()
        {
            IMazeCellFactory factoryTested = new BasicMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   # ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeWall>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeCorridor_For_Space()
        {
            IMazeCellFactory factoryTested = new BasicMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("######");
            mazeDef.AppendLine("### ##");
            mazeDef.AppendLine("######");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeCorridor>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }
    }
}
