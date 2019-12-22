using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes.Factories
{
    public class DayFifteenMazeFactory : BasicMazeFactory
    {
        public override MazeCell GetCellForPos(int x, int y, char[][] allMaze)
        {
            if (allMaze[y][x] == 'o')
                return new MazeOxygen(x, y);
            return base.GetCellForPos(x, y, allMaze);
        }
    }
}
