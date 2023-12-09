namespace AdventOfCode2023.GhostDesert
{
    internal class MapNode
    {
        public MapNode Left { get; internal set; }
        public MapNode Right { get; internal set; }
        public string Name { get; internal set; }

        public MapNode(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} => ({Left.Name}, {Right.Name})";
        }
    }
}