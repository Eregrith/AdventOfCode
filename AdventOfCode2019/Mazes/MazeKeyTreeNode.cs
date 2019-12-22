using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazeKeyTreeNode
    {
        public int StepsAway { get; set; }
        public string KeysUpToHere { get; set; }
        public List<MazeKeyTreeNode> Children { get; set; }
        public MazeCell Position { get; set; }

        public MazeKeyTreeNode(MazeCell position, string keysUptoHere, int stepsAway)
        {
            Position = position;
            KeysUpToHere = keysUptoHere;
            StepsAway = stepsAway;
            Children = new List<MazeKeyTreeNode>();
        }
    }
}
