using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes.Factories
{
    public class DayEighteenMazeFactory : BasicMazeFactory
    {
        public override MazeCell GetCellForPos(int x, int y, char[][] allMaze)
        {
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (lowerCase.Contains(allMaze[y][x]))
                return new MazeKey(allMaze[y][x], x, y);
            if (upperCase.Contains(allMaze[y][x]))
                return new MazeDoor(allMaze[y][x], x, y);
            if (allMaze[y][x] == '@')
                return new MazeEntrance(x, y);
            if (allMaze[y][x] == '.')
                return new MazeCorridor(x, y);
            return base.GetCellForPos(x, y, allMaze);
        }
    }
}
