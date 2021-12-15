using System.Collections.Generic;

namespace AdventOfCode2021.Caverns
{
    internal class CaveRoom
    {
        public string Name { get; internal set; }
        public bool IsBigRoom { get; internal set; }
        public List<CaveRoom> ConnectedTo { get; internal set; }
    }
}