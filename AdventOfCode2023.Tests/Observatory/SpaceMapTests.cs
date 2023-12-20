using AdventOfCode2023.Observatory;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests.Observatory
{
    internal class SpaceMapTests
    {
        [Test]
        public void FromInputMatrix_Should_Create_SpaceMap_From_Given_Input()
        {
            char[][] inputMatrix = new char[][]
            {
                new [] { '.', '.', '.', '.', '.', '.' },
                new [] { '.', '.', '.', '#', '.', '.' },
                new [] { '.', '.', '.', '.', '.', '.' },
                new [] { '.', '.', '.', '.', '.', '.' },
            };

            SpaceMap map = SpaceMap.FromInputMatrix(inputMatrix);

            map.Galaxies.Should().HaveCount(1);
            map.Galaxies.First().MapCoordinateX.Should().Be(3);
            map.Galaxies.First().MapCoordinateY.Should().Be(1);
        }

        [Test]
        public void ExpandSpace_Should_Transform_Coordinates_Based_On_Empty_Lines_And_Columns()
        {
            char[][] inputMatrix = new char[][]
            {
                new [] { '.', '.', '.', '.' },
                new [] { '.', '#', '.', '.' },
                new [] { '.', '.', '.', '.' },
                new [] { '.', '.', '.', '#' },
            };

            SpaceMap map = SpaceMap.FromInputMatrix(inputMatrix);

            map.ExpandSpace(1);

            map.Galaxies[0].MapCoordinateX.Should().Be(1);
            map.Galaxies[0].ExpandedCoordinateX.Should().Be(2);
            map.Galaxies[0].MapCoordinateY.Should().Be(1);
            map.Galaxies[0].ExpandedCoordinateY.Should().Be(2);
            map.Galaxies[1].MapCoordinateX.Should().Be(3);
            map.Galaxies[1].ExpandedCoordinateX.Should().Be(5);
            map.Galaxies[1].MapCoordinateY.Should().Be(3);
            map.Galaxies[1].ExpandedCoordinateY.Should().Be(5);
        }

        [Test]
        public void CalculatePaths_Should_Return_One_Path_When_There_Is_Only_One_Pair_Of_Galaxies()
        {
            char[][] inputMatrix = new char[][]
            {
                new [] { '.', '.', '.', '.' },
                new [] { '.', '#', '.', '.' },
                new [] { '.', '.', '.', '.' },
                new [] { '.', '.', '.', '#' },
            };

            SpaceMap map = SpaceMap.FromInputMatrix(inputMatrix);

            List<int> pathsLengths = map.CalculatePaths();

            pathsLengths.Should().HaveCount(1);
            pathsLengths[0].Should().Be(4);
        }

        [Test]
        public void CalculatePaths_Should_Return_Three_Paths_When_There_are_Three_Pairs_Of_Galaxies()
        {
            char[][] inputMatrix = new char[][]
            {
                new [] { '.', '.', '.', '#', '.' },
                new [] { '.', '.', '.', '.', '.' },
                new [] { '.', '.', '.', '.', '.' },
                new [] { '.', '.', '.', '.', '.' },
                new [] { '#', '.', '.', '.', '#' },
            };

            SpaceMap map = SpaceMap.FromInputMatrix(inputMatrix);

            List<int> pathsLengths = map.CalculatePaths();

            pathsLengths.Should().HaveCount(3);
            pathsLengths.OrderBy(p => p).Should().ContainInOrder(new List<int> { 4, 5, 7 });
        }
    }
}
