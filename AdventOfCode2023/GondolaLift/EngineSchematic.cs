using System.Text;

namespace AdventOfCode2023.GondolaLift
{
    internal class EngineSchematic
    {
        public int Width { get; internal set; }
        public char[][] Matrix { get; private set; }
        public int Height { get; internal set; }
        public List<EnginePart> Parts { get; internal set; } = new List<EnginePart>();
        public List<EngineGear> Gears { get; internal set; } = new List<EngineGear>();
        private Dictionary<(int x, int y), List<EnginePart>> Anchors = new Dictionary<(int x, int y), List<EnginePart>>();

        internal static EngineSchematic FromMatrix(char[][] matrix)
        {
            EngineSchematic schematic = new EngineSchematic();

            schematic.Height = matrix.Length;
            schematic.Width = matrix[0].Length;
            schematic.Matrix = matrix;

            schematic.LookForParts();

            return schematic;
        }

        private void LookForParts()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (Char.IsDigit(CharAt(x, y)))
                    {
                        EnginePart part = ExtractEnginePartFrom(y, x);
                        x += part.Length;
                        if (part.Anchor != null)
                        {
                            Parts.Add(part);
                            if (part.Anchor.IsPotentialGear)
                            {
                                if (Anchors.Keys.Any(a => a.x == part.Anchor.X && a.y == part.Anchor.Y))
                                {
                                    Anchors[(part.Anchor.X, part.Anchor.Y)].Add(part);
                                }
                                else
                                {
                                    Anchors[(part.Anchor.X, part.Anchor.Y)] = new() { part };
                                }
                            }
                        }
                    }
                }
            }

            foreach (List<EnginePart> connectedParts in Anchors.Values)
            {
                if (connectedParts.Count == 2)
                {
                    Gears.Add(new EngineGear(connectedParts[0], connectedParts[1]));
                }
            }
        }

        private EnginePart ExtractEnginePartFrom(int y, int x)
        {
            StringBuilder numberBuilder = new StringBuilder();
            SchematicAnchor? anchor = null;

            while (x < Width && Char.IsDigit(CharAt(x, y)))
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        char c = CharAt(x + i, y + j);
                        if (!Char.IsDigit(c) && c != '.')
                        {
                            anchor = new SchematicAnchor(c, x + i, y + j);
                        }
                    }
                }
                numberBuilder.Append(CharAt(x, y));
                x++;
            }

            var part = new EnginePart();
            string partNumber = numberBuilder.ToString();
            part.Number = int.Parse(partNumber);
            part.Length = partNumber.Length;
            part.Anchor = anchor;
            return part;
        }

        internal char CharAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return '.';
            return Matrix[y][x];
        }
    }
}
