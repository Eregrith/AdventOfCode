using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazeWall : MazeCell
    {
        public override char Display => '#';

        public MazeWall(int x, int y)
            : base(x, y)
        {}
    }
}
