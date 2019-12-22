using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazePortal : MazeCell
    {
        public string Id { get; }

        public MazePortal(int x, int y, string id) : base(x, y)
        {
            Id = id;
        }
    }
}
