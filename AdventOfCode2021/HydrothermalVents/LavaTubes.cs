using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.HydrothermalVents
{
    internal class LavaTubes
    {
        private readonly int[][] _soil;

        public LavaTubes(int[][] soil)
        {
            _soil = soil;
        }

        internal int GetLowPointsRiskLevelSum()
        {
            List<(int x, int y)> lowPoints = GetLowPoints();

            return lowPoints.Aggregate(0, (agg, t) => _soil[t.y][t.x] + agg + 1);
        }

        private List<(int x, int y)> GetLowPoints()
        {
            List<(int x, int y)> lowPoints = new List<(int x, int y)>();
            for (int y = 0; y < _soil.Length; y++)
            {
                for (int x = 0; x < _soil[y].Length; x++)
                {
                    if (IsLowPoint(x, y))
                    {
                        lowPoints.Add((x, y));
                    }
                }
            }

            return lowPoints;
        }

        private bool IsLowPoint(int x, int y)
        {
            int height = _soil[y][x];
            bool aboveIsHigher = DoesNotExistsOrIsHigherThan(x, y - 1, height);
            bool underIsHigher = DoesNotExistsOrIsHigherThan(x, y + 1, height);
            bool leftIsHigher = DoesNotExistsOrIsHigherThan(x - 1, y, height);
            bool rightIsHigher = DoesNotExistsOrIsHigherThan(x + 1, y, height);

            return aboveIsHigher && underIsHigher && leftIsHigher && rightIsHigher;
        }

        internal int GetProductOfBasinSizes()
        {
            List<(int x, int y)> lowPoints = GetLowPoints();
            List<List<(int x, int y)>> basins = new List<List<(int x, int y)>>();

            foreach (var lowPoint in lowPoints)
            {
                basins.Add(GetBasinFrom(lowPoint));
            }

            return basins.OrderByDescending(b => b.Count).Take(3).Aggregate(1, (agg, basin) => agg * basin.Count);
        }

        private List<(int x, int y)> GetBasinFrom((int x, int y) lowPoint)
        {
            List<(int x, int y)> basin = new List<(int x, int y)>();

            basin.Add(lowPoint);
            PropagateBasinFrom(lowPoint, basin);
            return basin;
        }

        private void PropagateBasinFrom((int x, int y) p, List<(int x, int y)> basin)
        {
            TryPropagateAt(basin, p.x + 1, p.y);
            TryPropagateAt(basin, p.x - 1, p.y);
            TryPropagateAt(basin, p.x, p.y + 1);
            TryPropagateAt(basin, p.x, p.y - 1);
        }

        private void TryPropagateAt(List<(int x, int y)> basin, int x, int y)
        {
            if (!basin.Contains((x, y)) && Exists(x, y) && _soil[y][x] != 9)
            {
                basin.Add((x, y));
                PropagateBasinFrom((x, y), basin);
            }
        }

        private bool DoesNotExistsOrIsHigherThan(int x, int y, int height)
        {
            return (!Exists(x, y) || _soil[y][x] > height);
        }

        private bool Exists(int x, int y) => x >= 0 && y >= 0 && y < _soil.Length && x < _soil[y].Length;

    }
}
