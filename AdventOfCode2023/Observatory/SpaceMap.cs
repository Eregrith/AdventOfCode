using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Observatory
{
    internal class SpaceMap
    {
        private readonly int _height;
        private readonly int _width;
        public List<Galaxy> Galaxies { get; set; }

        private SpaceMap(int height, int width, List<Galaxy> galaxies)
        {
            _height = height;
            _width = width;
            Galaxies = galaxies;
        }

        public static SpaceMap FromInputMatrix(char[][] inputMatrix)
        {
            List<Galaxy> galaxies = new List<Galaxy>();

            for (int y = 0; y < inputMatrix.Length; y++)
            {
                for (int x = 0; x < inputMatrix[y].Length; x++)
                {
                    if (inputMatrix[y][x] == '#')
                    {
                        galaxies.Add(new Galaxy(x, y));
                    }
                }
            }

            return new SpaceMap(inputMatrix.Length, inputMatrix[0].Length, galaxies.OrderBy(g => g.MapCoordinateX + g.MapCoordinateY).ToList());
        }

        public void ExpandSpace(int expansion)
        {
            for (int x = 0; x < _width; x++)
            {
                bool atLeastOneGalaxyInThisColumn = Galaxies.Any(g => g.MapCoordinateX == x);
                if (!atLeastOneGalaxyInThisColumn)
                {
                    Galaxies.Where(g => g.MapCoordinateX > x).ToList()
                        .ForEach(g => g.ExpandedCoordinateX += expansion);
                }
            }

            for (int y = 0; y < _height; y++)
            {
                bool atLeastOneGalaxyInThisRow = Galaxies.Any(g => g.MapCoordinateY == y);
                if (!atLeastOneGalaxyInThisRow)
                {
                    Galaxies.Where(g => g.MapCoordinateY > y).ToList()
                        .ForEach(g => g.ExpandedCoordinateY += expansion);
                }
            }
        }

        public List<int> CalculatePaths()
        {
            List<int> paths = new List<int>();

            for (int i = 0; i < Galaxies.Count - 1; i++)
            {
                Galaxy source = Galaxies[i];
                for (int j = i + 1; j < Galaxies.Count; j++)
                {
                    Galaxy dest = Galaxies[j];
                    int distance = Math.Abs(source.ExpandedCoordinateX - dest.ExpandedCoordinateX)
                                   + Math.Abs(source.ExpandedCoordinateY - dest.ExpandedCoordinateY);
                    paths.Add(distance);
                }
            }

            return paths;
        }
    }

    internal class Galaxy
    {
        public int MapCoordinateX { get; set; }
        public int MapCoordinateY { get; set; }
        public int ExpandedCoordinateX { get; set; }
        public int ExpandedCoordinateY { get; set; }

        public Galaxy(int x, int y)
        {
            MapCoordinateX = x;
            ExpandedCoordinateX = x;
            MapCoordinateY = y;
            ExpandedCoordinateY = y;
        }
    }
}