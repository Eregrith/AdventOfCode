using AdventOfCode2019.Mazes.Factories;
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

        public Maze(char[][] mazeDef, IMazeCellFactory cellFactory)
        {
            for (int y = 0; y < mazeDef.Length; y++)
                for (int x = 0; x < mazeDef[y].Length; x++)
                    Cells.Add(cellFactory.GetCellForPos(x, y, mazeDef));
        }

        public void SetDistancesFrom(MazeCell position)
        {
            string keysRequired = "";
            SetDistanceAndPropagate(0, position.X, position.Y, keysRequired);
        }

        private void SetDistanceAndPropagate(int distance, int x, int y, string keysRequired)
        {
            MazeCell c = CellAt(x, y);
            if (c == null) return;
            if (c.DistanceFromStart >= 0 && c.DistanceFromStart <= distance + 1) return;
            if (c is MazeWall) return;
            if (c is MazeDoor door) keysRequired += door.KeyNeeded;
            if (c is MazeKey key)
            {
                key.KeysRequired = keysRequired;
                keysRequired += key.Id;
            }
            c.DistanceFromStart = distance;
            if (c is MazePortal portal)
            {
                MazeCell otherEnd = Cells.OfType<MazePortal>().First(p => p.Id == portal.Id && p != c);
                SetDistanceAndPropagate(distance + 1, otherEnd.X, otherEnd.Y, keysRequired);
            }
            SetDistanceAndPropagate(distance + 1, x + 1, y, keysRequired);
            SetDistanceAndPropagate(distance + 1, x - 1, y, keysRequired);
            SetDistanceAndPropagate(distance + 1, x, y + 1, keysRequired);
            SetDistanceAndPropagate(distance + 1, x, y - 1, keysRequired);
        }

        public void ResetCells()
        {
            Cells.ForEach(c =>
            { 
                c.DistanceFromStart = -1;
                if (c is MazeKey key) key.KeysRequired = "";
            });
        }

        public int MinX => Cells.Min(c => c.X);
        public int MaxX => Cells.Max(c => c.X);
        public int MinY => Cells.Min(c => c.Y);

        public void PropagateOxygen()
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

        public void AddWallAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeWall(x, y));
        }

        public void AddCorridorAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeCorridor(x, y));
        }

        public MazeCell CellAt(int x, int y)
        {
            return Cells.FirstOrDefault(c => c.X == x && c.Y == y);
        }

        public void AddExitAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeExit(x, y));
        }

        public void AddStartAt(int x, int y)
        {
            if (Cells.Any(c => c.X == x && c.Y == y)) return;
            Cells.Add(new MazeEntrance(x, y));
        }

        public string GetDisplay()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = MinY; y <= MaxY; y++)
            {
                for (int x = MinX; x <= MaxX; x++)
                {
                    MazeCell c = CellAt(x, y);
                    if (c == null) sb.Append('?');
                    else sb.Append(c.Display);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
