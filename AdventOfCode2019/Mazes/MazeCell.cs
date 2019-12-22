using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazeCell
    {
        public int X;
        public int Y;
        public virtual char Display { get; }
        public int DistanceFromStart { get; internal set; }

        public MazeCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
