using AdventOfCode2019.Mazes;
using AdventOfCode2019.Mazes.Factories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Tests.Mazes
{
    [TestFixture]
    class MazeTests
    {
        [Test]
        public void Maze_Construction_Should_Use_CellFactory()
        {
            Mock<IMazeCellFactory> mockCellFactory = new Mock<IMazeCellFactory>();
            mockCellFactory.Setup(m => m.GetCellForPos(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char[][]>()))
                .Returns((int x, int y, char[][] allMaze) => new MazeKey('x', x, y));
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("#");
            var allMaze = mazeDef.ToString().ToDoubleCharArray();
            Maze m = new Maze(allMaze, mockCellFactory.Object);

            mockCellFactory.Verify(m => m.GetCellForPos(0, 0, allMaze), Times.Once);
            m.Cells.First().Should().BeOfType<MazeKey>();
        }

        [Test]
        public void SetDistanceFromStart_Should_Use_Portals_When_Available()
        {
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("########");
            mazeDef.AppendLine("##BC..ZZ");
            mazeDef.AppendLine("########");
            mazeDef.AppendLine("AA..BC##");
            mazeDef.AppendLine("########");
            var allMaze = mazeDef.ToString().ToDoubleCharArray();
            Maze m = new Maze(allMaze, new DayTwentyMazeFactory());
            MazeEntrance e = m.Cells.OfType<MazeEntrance>().First();
            m.ResetCells();

            m.SetDistancesFrom(e);

            m.Cells.OfType<MazeExit>().First().DistanceFromStart.Should().Be(3);
        }

        [Test]
        public void SetDistanceFromStart_Should_Work_On_Large_Mazes_With_Multiple_Portals()
        {
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("         A         ");
            mazeDef.AppendLine("         A         ");
            mazeDef.AppendLine("  #######.#########");
            mazeDef.AppendLine("  #######.........#");
            mazeDef.AppendLine("  #######.#######.#");
            mazeDef.AppendLine("  #######.#######.#");
            mazeDef.AppendLine("  #######.#######.#");
            mazeDef.AppendLine("  #####  B    ###.#");
            mazeDef.AppendLine("BC...##  C    ###.#");
            mazeDef.AppendLine("  ##.##       ###.#");
            mazeDef.AppendLine("  ##...DE  F  ###.#");
            mazeDef.AppendLine("  #####    G  ###.#");
            mazeDef.AppendLine("  #########.#####.#");
            mazeDef.AppendLine("DE..#######...###.#");
            mazeDef.AppendLine("  #.#########.###.#");
            mazeDef.AppendLine("FG..#########.....#");
            mazeDef.AppendLine("  ###########.#####");
            mazeDef.AppendLine("             Z     ");
            mazeDef.AppendLine("             Z     ");
            var allMaze = mazeDef.ToString().ToDoubleCharArray();
            Maze m = new Maze(allMaze, new DayTwentyMazeFactory());
            MazeEntrance e = m.Cells.OfType<MazeEntrance>().First();
            m.ResetCells();

            m.SetDistancesFrom(e);

            m.Cells.OfType<MazeExit>().First().DistanceFromStart.Should().Be(23);
        }

        [Test]
        public void SetDistanceFromStart_Should_Work_On_Very_Large_Mazes_With_Multiple_Portals()
        {
            StringBuilder mazeDef = new StringBuilder();
            mazeDef.AppendLine("                   A               ");
            mazeDef.AppendLine("                   A               ");
            mazeDef.AppendLine("  #################.#############  ");
            mazeDef.AppendLine("  #.#...#...................#.#.#  ");
            mazeDef.AppendLine("  #.#.#.###.###.###.#########.#.#  ");
            mazeDef.AppendLine("  #.#.#.......#...#.....#.#.#...#  ");
            mazeDef.AppendLine("  #.#########.###.#####.#.#.###.#  ");
            mazeDef.AppendLine("  #.............#.#.....#.......#  ");
            mazeDef.AppendLine("  ###.###########.###.#####.#.#.#  ");
            mazeDef.AppendLine("  #.....#        A   C    #.#.#.#  ");
            mazeDef.AppendLine("  #######        S   P    #####.#  ");
            mazeDef.AppendLine("  #.#...#                 #......VT");
            mazeDef.AppendLine("  #.#.#.#                 #.#####  ");
            mazeDef.AppendLine("  #...#.#               YN....#.#  ");
            mazeDef.AppendLine("  #.###.#                 #####.#  ");
            mazeDef.AppendLine("DI....#.#                 #.....#  ");
            mazeDef.AppendLine("  #####.#                 #.###.#  ");
            mazeDef.AppendLine("ZZ......#               QG....#..AS");
            mazeDef.AppendLine("  ###.###                 #######  ");
            mazeDef.AppendLine("JO..#.#.#                 #.....#  ");
            mazeDef.AppendLine("  #.#.#.#                 ###.#.#  ");
            mazeDef.AppendLine("  #...#..DI             BU....#..LF");
            mazeDef.AppendLine("  #####.#                 #.#####  ");
            mazeDef.AppendLine("YN......#               VT..#....QG");
            mazeDef.AppendLine("  #.###.#                 #.###.#  ");
            mazeDef.AppendLine("  #.#...#                 #.....#  ");
            mazeDef.AppendLine("  ###.###    J L     J    #.#.###  ");
            mazeDef.AppendLine("  #.....#    O F     P    #.#...#  ");
            mazeDef.AppendLine("  #.###.#####.#.#####.#####.###.#  ");
            mazeDef.AppendLine("  #...#.#.#...#.....#.....#.#...#  ");
            mazeDef.AppendLine("  #.#####.###.###.#.#.#########.#  ");
            mazeDef.AppendLine("  #...#.#.....#...#.#.#.#.....#.#  ");
            mazeDef.AppendLine("  #.###.#####.###.###.#.#.#######  ");
            mazeDef.AppendLine("  #.#.........#...#.............#  ");
            mazeDef.AppendLine("  #########.###.###.#############  ");
            mazeDef.AppendLine("           B   J   C               ");
            mazeDef.AppendLine("           U   P   P               ");
            var allMaze = mazeDef.ToString().ToDoubleCharArray();
            Maze m = new Maze(allMaze, new DayTwentyMazeFactory());
            MazeEntrance e = m.Cells.OfType<MazeEntrance>().First();
            m.ResetCells();

            m.SetDistancesFrom(e);

            m.Cells.OfType<MazeExit>().First().DistanceFromStart.Should().Be(58);
        }
    }
}
