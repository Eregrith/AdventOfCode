using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Mazes
{
    public class MazePath
    {
        public string KeysRequired { get; set; }
        public int Steps { get; set; }
        public char From { get; set; }
        public char To { get; set; }

        public bool CanReachWith(string keys)
        {
            return KeysRequired.All(k => keys.Contains(k));
        }

        public MazePath(MazeCell from, MazeKey k, int stepsAway, string keysRequired)
        {
            From = from.Display;
            To = k.Display;
            Steps = stepsAway;
            KeysRequired = keysRequired;
        }

        public override string ToString()
        {
            return $"Path from {From} to {To} takes {Steps} steps and requires keys {KeysRequired}";
        }
    }
}
