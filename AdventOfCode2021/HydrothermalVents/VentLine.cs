using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode2021.HydrothermalVents
{
    public class VentLine
    {
        public Point Start { get; private set; }
        public Point End { get; private set; }

        public bool IsVerical => Start.Y == End.Y;
        public bool IsHorizontal => Start.X == End.X;

        public static VentLine Parse(string line)
        {
            VentLine v = new VentLine();
            string[] points = line.Split(" -> ");
            string[] start = points[0].Split(",");
            string[] end = points[1].Split(",");
            v.Start = new Point(int.Parse(start[0]), int.Parse(start[1]));
            v.End = new Point(int.Parse(end[0]), int.Parse(end[1]));
            return v;
        }

        internal void MarkFloor(int[][] floor)
        {
            int y = Start.Y;
            int x = Start.X;
            int ydirection = 0;
            if (Start.Y < End.Y) ydirection = 1;
            if (End.Y < Start.Y) ydirection = -1;
            int xdirection = 0;
            if (Start.X < End.X) xdirection = 1;
            if (End.X < Start.X) xdirection = -1;
            while (y != End.Y || x != End.X)
            {
                floor[y - 1][x - 1]++;
                y += ydirection;
                x += xdirection;
            }
            floor[y - 1][x - 1]++;
        }
    }
}
