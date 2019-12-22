using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes.Factories
{
    public class BasicMazeFactory : IMazeCellFactory
    {
        public virtual MazeCell GetCellForPos(int x, int y, char[][] allMaze)
        {
            if (allMaze[y][x] == '#')
                return new MazeWall(x, y);
            if (allMaze[y][x] == ' ')
                return new MazeCorridor(x, y);
            return new MazeCell(x, y);
        }
    }
}
