using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes.Factories
{
    public interface IMazeCellFactory
    {
        MazeCell GetCellForPos(int x, int y, char[][] allMaze);
    }
}
