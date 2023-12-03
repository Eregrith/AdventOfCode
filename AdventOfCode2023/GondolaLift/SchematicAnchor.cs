namespace AdventOfCode2023.GondolaLift
{
    internal class SchematicAnchor
    {
        private char _anchor;
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPotentialGear => _anchor == '*';

        public SchematicAnchor(char anchor, int x, int y)
        {
            _anchor = anchor;
            X = x;
            Y = y;
        }
    }
}