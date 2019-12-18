using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class Maze
    {
        public Maze()
        { }

        public Maze(char[][] v)
        {
            for (int y = 0; y < v.Length; y++)
            {
                for (int x = 0; x < v[y].Length; x++)
                {
                    switch (v[y][x])
                    {
                        case '#':
                            AddWallAt(x, y);
                            break;
                        case ' ':
                            AddCorridorAt(x, y);
                            break;
                        case 'o':
                            AddOxygenAt(x, y);
                            break;
                    }
                }
            }
        }

        public int MinX => Cells.Min(c => c.X);
        public int MaxX => Cells.Max(c => c.X);
        public int MinY => Cells.Min(c => c.Y);

        internal void PropagateOxygen()
        {
            var oxygenCells = Cells.OfType<MazeOxygen>().Where(c => c.IsActive).ToList();
            foreach (MazeOxygen oxygen in oxygenCells)
            {
                bool propagateLeft = PutOxygen(oxygen.X - 1, oxygen.Y);
                bool propagateRight = PutOxygen(oxygen.X + 1, oxygen.Y);
                bool propagateUp = PutOxygen(oxygen.X, oxygen.Y - 1);
                bool propagateDown = PutOxygen(oxygen.X, oxygen.Y + 1);

                if (!(propagateDown || propagateUp || propagateLeft || propagateRight))
                    oxygen.IsActive = false;
            }
        }

        private bool PutOxygen(int x, int y)
        {
            MazeCell c = CellAt(x, y);
            if (c == null) return false;
            if (!(c is MazeCorridor)) return false;

            Cells.Remove(c);
            Cells.Add(new MazeOxygen(x, y));
            return true;
        }

        public int MaxY => Cells.Max(c => c.Y);

        public List<MazeCell> Cells { get; set; } = new List<MazeCell>();

        internal void AddWallAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeWall(x, y));
        }

        internal void AddCorridorAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeCorridor(x, y));
        }

        private void AddOxygenAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeOxygen(x, y));
        }

        internal MazeCell CellAt(int x, int y)
        {
            return Cells.FirstOrDefault(c => c.X == x && c.Y == y);
        }

        internal void AddExitAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeExit(x, y));
        }

        internal void AddStartAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeEntrance(x, y));
        }
    }
}
