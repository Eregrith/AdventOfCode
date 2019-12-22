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
    class DayTwentyMazeFactoryTests
    {
        [Test]
        public void DayTwentyMazeFactory_Should_BeDerivedFrom_BasicMazeFactory()
        {
            typeof(DayTwentyMazeFactory).Should().BeDerivedFrom<BasicMazeFactory>();
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeCorridor_For_Dot()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
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
        public void GetCellForPos_Should_Return_MazePortal_For_Dot_Next_To_Vertical_Double_Upper_Case_Letters_Below()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   . ");
            mazeDef.AppendLine("   B ");
            mazeDef.AppendLine("   C ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazePortal>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazePortal).Id.Should().Be("BC");
        }

        [Test]
        public void GetCellForPos_Should_Return_MazePortal_For_Dot_Next_To_Vertical_Double_Upper_Case_Letters_Above()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("   B ");
            mazeDef.AppendLine("   C ");
            mazeDef.AppendLine("   . ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazePortal>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazePortal).Id.Should().Be("BC");
        }

        [Test]
        public void GetCellForPos_Should_Return_MazePortal_For_Dot_Next_To_Horizontal_Double_Upper_Case_Letters_After()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("   .BC");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazePortal>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazePortal).Id.Should().Be("BC");
        }

        [Test]
        public void GetCellForPos_Should_Return_MazePortal_For_Dot_Next_To_Horizontal_Double_Upper_Case_Letters_Before()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine(" BC.  ");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazePortal>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
            (cell as MazePortal).Id.Should().Be("BC");
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeEntrance_For_Dot_Next_To_AA_Above()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("   A  ");
            mazeDef.AppendLine("   A  ");
            mazeDef.AppendLine("   .  ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeEntrance>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeEntrance_For_Dot_Next_To_AA_Before()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine(" AA.  ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeEntrance>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeEntrance_For_Dot_Next_To_AA_Below()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("   .  ");
            mazeDef.AppendLine("   A  ");
            mazeDef.AppendLine("   A  ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeEntrance>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeEntrance_For_Dot_Next_To_AA_After()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("   .AA");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeEntrance>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeExit_For_Dot_Next_To_ZZ_Above()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("   Z  ");
            mazeDef.AppendLine("   Z  ");
            mazeDef.AppendLine("   .  ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeExit>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeExit_For_Dot_Next_To_ZZ_Before()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine(" ZZ.  ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeExit>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeExit_For_Dot_Next_To_ZZ_Below()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("   .  ");
            mazeDef.AppendLine("   Z  ");
            mazeDef.AppendLine("   Z  ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeExit>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeExit_For_Dot_Next_To_ZZ_After()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 2;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("      ");
            mazeDef.AppendLine("   .ZZ");
            mazeDef.AppendLine("      ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeExit>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }

        [Test]
        public void GetCellForPos_Should_Return_MazeWall_For_Anything_Else()
        {
            IMazeCellFactory factoryTested = new DayTwentyMazeFactory();
            int x = 3;
            int y = 1;
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("     ");
            mazeDef.AppendLine("   B ");
            mazeDef.AppendLine("     ");
            MazeCell cell = factoryTested.GetCellForPos(x, y, mazeDef.ToString().ToDoubleCharArray());

            cell.Should().BeOfType<MazeWall>();
            cell.X.Should().Be(x);
            cell.Y.Should().Be(y);
        }
    }
}
