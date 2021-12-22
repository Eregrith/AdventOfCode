using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2021.Origami
{
    internal class OrigamiManual
    {
        private List<Point> _points;
        private readonly Queue<FoldingInstruction> _instructions;

        public int CountDots => _points.Count;

        public OrigamiManual(List<string> points, List<string> instructions)
        {
            _points = points.Select(p =>
            {
                string[] parts = p.Split(',', StringSplitOptions.RemoveEmptyEntries);
                return new Point(int.Parse(parts[0]), int.Parse(parts[1]));
            }).ToList();

            _instructions = new Queue<FoldingInstruction>(instructions.Select(i => FoldingInstruction.Parse(i)));
        }

        internal void FoldOnceAndRemoveDuplicates()
        {
            FoldingInstruction currentFold = _instructions.Dequeue();

            _points = currentFold.FoldAndRemoveDuplicates(_points);
        }

        internal void CompleteAllFolds()
        {
            while (_instructions.Count > 0)
            {
                FoldOnceAndRemoveDuplicates();
            }
        }

        internal void Display()
        {
            foreach (Point point in _points)
            {
                Console.SetCursorPosition(point.X, point.Y + 10);
                Console.Write("#");
            }
        }
    }
}
