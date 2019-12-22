using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes.Factories
{
    public class DayTwentyMazeFactory : BasicMazeFactory
    {
        public override MazeCell GetCellForPos(int x, int y, char[][] allMaze)
        {
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (allMaze[y][x] == '.')
            {
                if (IsInMaze(x - 1, y, allMaze) && allMaze[y][x - 1] == 'A'
                    && IsInMaze(x - 2, y, allMaze) && allMaze[y][x - 2] == 'A')
                    return new MazeEntrance(x, y);
                if (IsInMaze(x + 1, y, allMaze) && allMaze[y][x + 1] == 'A'
                    && IsInMaze(x + 2, y, allMaze) && allMaze[y][x + 2] == 'A')
                    return new MazeEntrance(x, y);
                if (IsInMaze(x, y - 1, allMaze) && allMaze[y - 1][x] == 'A'
                    && IsInMaze(x, y - 2, allMaze) && allMaze[y - 2][x] == 'A')
                    return new MazeEntrance(x, y);
                if (IsInMaze(x, y + 1, allMaze) && allMaze[y + 1][x] == 'A'
                    && IsInMaze(x, y + 2, allMaze) && allMaze[y + 2][x] == 'A')
                    return new MazeEntrance(x, y);
                if (IsInMaze(x - 1, y, allMaze) && allMaze[y][x - 1] == 'Z'
                    && IsInMaze(x - 2, y, allMaze) && allMaze[y][x - 2] == 'Z')
                    return new MazeExit(x, y);
                if (IsInMaze(x + 1, y, allMaze) && allMaze[y][x + 1] == 'Z'
                    && IsInMaze(x + 2, y, allMaze) && allMaze[y][x + 2] == 'Z')
                    return new MazeExit(x, y);
                if (IsInMaze(x, y - 1, allMaze) && allMaze[y - 1][x] == 'Z'
                    && IsInMaze(x, y - 2, allMaze) && allMaze[y - 2][x] == 'Z')
                    return new MazeExit(x, y);
                if (IsInMaze(x, y + 1, allMaze) && allMaze[y + 1][x] == 'Z'
                    && IsInMaze(x, y + 2, allMaze) && allMaze[y + 2][x] == 'Z')
                    return new MazeExit(x, y);
                if (IsInMaze(x, y - 1, allMaze) && uppercase.Contains(allMaze[y - 1][x])
                    && IsInMaze(x, y - 2, allMaze) && uppercase.Contains(allMaze[y - 2][x]))
                    return new MazePortal(x, y, "" + allMaze[y - 2][x] + allMaze[y - 1][x]);
                if (IsInMaze(x, y + 1, allMaze) && uppercase.Contains(allMaze[y + 1][x])
                    && IsInMaze(x, y + 2, allMaze) && uppercase.Contains(allMaze[y + 2][x]))
                    return new MazePortal(x, y, "" + allMaze[y + 1][x] + allMaze[y + 2][x]);
                if (IsInMaze(x + 1, y, allMaze) && uppercase.Contains(allMaze[y][x + 1])
                    && IsInMaze(x + 2, y, allMaze) && uppercase.Contains(allMaze[y][x + 2]))
                    return new MazePortal(x, y, "" + allMaze[y][x + 1] + allMaze[y][x + 2]);
                if (IsInMaze(x - 1, y, allMaze) && uppercase.Contains(allMaze[y][x - 1])
                    && IsInMaze(x - 2, y, allMaze) && uppercase.Contains(allMaze[y][x - 2]))
                    return new MazePortal(x, y, "" + allMaze[y][x - 2] + allMaze[y][x - 1]);
                return new MazeCorridor(x, y);
            }
            return new MazeWall(x, y);
        }

        private bool IsInMaze(int x, int y, char[][] allMaze)
        {
            if (x < 0) return false;
            if (y < 0) return false;
            if (y > allMaze.Length) return false;
            if (x > allMaze[y].Length) return false;
            return true;
        }
    }
}
