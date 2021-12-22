using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2021.Origami
{
    internal class FoldingInstruction
    {
        public enum FoldingAxis { X, Y };
        private readonly FoldingAxis _axis;
        private readonly int _coordinate;

        public FoldingInstruction(FoldingAxis axis, int coord)
        {
            _axis = axis;
            _coordinate = coord;
        }

        internal static FoldingInstruction Parse(string line)
        {
            string[] parts = line.Split('=');
            FoldingAxis axis = FoldingAxis.X;
            if (parts[0].EndsWith('y'))
                axis = FoldingAxis.Y;
            return new FoldingInstruction(axis, int.Parse(parts[1]));
        }

        internal List<Point> FoldAndRemoveDuplicates(List<Point> points)
        {
            List<Point> newPoints = new List<Point>();

            foreach (Point point in points)
            {
                int x = point.X;
                int y = point.Y;
                if (_axis == FoldingAxis.X && x > _coordinate)
                {
                    x = _coordinate - (x - _coordinate);
                }
                else if (_axis == FoldingAxis.Y && y > _coordinate)
                {
                    y = _coordinate - (y - _coordinate);
                }
                if (!newPoints.Any(p => p.X == x && p.Y == y))
                    newPoints.Add(new Point(x, y));
            }
            return newPoints;
        }
    }
}