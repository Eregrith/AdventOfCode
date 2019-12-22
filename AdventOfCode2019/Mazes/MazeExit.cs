using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazeExit : MazeCell
    {
        public override char Display => '*';
        public MazeExit(int x, int y)
            : base(x, y)
        {
        }
    }
}
