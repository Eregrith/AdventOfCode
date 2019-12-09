using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public static class DayThree
    {
        public static void PartOne()
        {
            string[] input = InputHelper.GetInputFromFile("3").Split("\n");

            List<Tuple<char, int>> firstWireMoves = input[0].Split(",").Select(m => new Tuple<char, int>(m[0], int.Parse(m.Substring(1)))).ToList();
            List<Tuple<char, int>> secondWireMoves = input[1].Split(",").Select(m => new Tuple<char, int>(m[0], int.Parse(m.Substring(1)))).ToList();
            Queue<Tuple<int, int>> pointsWireOne = GetPoints(firstWireMoves);
            Queue<Tuple<int, int>> pointsWireTwo = GetPoints(secondWireMoves);
            (int xmin, int xmax) = (Math.Min(pointsWireOne.Min(p => p.Item1), pointsWireTwo.Min(p => p.Item1)), Math.Max(pointsWireOne.Max(p => p.Item1), pointsWireTwo.Max(p => p.Item1)));
            (int ymin, int ymax) = (Math.Min(pointsWireOne.Min(p => p.Item2), pointsWireTwo.Min(p => p.Item2)), Math.Max(pointsWireOne.Max(p => p.Item2), pointsWireTwo.Max(p => p.Item2)));
            int width = 3 + xmax - xmin;
            int height = 3 + ymax - ymin;
            char[,] grid = new char[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[y, x] = ' ';
                }
            }
            Queue<Tuple<int, int>> intersections = new Queue<Tuple<int, int>>();
            Trace(pointsWireOne, 'a', xmin, ymin, grid, intersections);
            Trace(pointsWireTwo, 'b', xmin, ymin, grid, intersections);
            Display(grid, width, height);
            int minDistance = int.MaxValue;
            while (intersections.Count > 0)
            {
                var t = intersections.Dequeue();
                int distance = Math.Abs(t.Item1 - 1 + xmin) + Math.Abs(t.Item2 - 1 + ymin);
                if (distance < minDistance)
                    minDistance = distance;
            }
            Console.WriteLine("Min distance : " + minDistance);
        }
        public static void PartTwo()
        {
            string[] input = InputHelper.GetInputFromFile("3").Split("\n");

            List<Tuple<char, int>> firstWireMoves = input[0].Split(",").Select(m => new Tuple<char, int>(m[0], int.Parse(m.Substring(1)))).ToList();
            List<Tuple<char, int>> secondWireMoves = input[1].Split(",").Select(m => new Tuple<char, int>(m[0], int.Parse(m.Substring(1)))).ToList();
            List<Tuple<int, int>> pointsWireOne = GetTraces(firstWireMoves);
            List<Tuple<int, int>> pointsWireTwo = GetTraces(secondWireMoves);

            var intersection = pointsWireOne.Intersect(pointsWireTwo).OrderBy(i => pointsWireOne.IndexOf(i) + pointsWireTwo.IndexOf(i)).First();
            Console.WriteLine($"Sum of steps : {pointsWireOne.IndexOf(intersection)} + {pointsWireTwo.IndexOf(intersection)} + 2 = {pointsWireOne.IndexOf(intersection) + pointsWireTwo.IndexOf(intersection) + 2}");
        }

        private static List<Tuple<int, int>> GetTraces(List<Tuple<char, int>> wireMoves)
        {
            Tuple<int, int> node = new Tuple<int, int>(0, 0);
            List<Tuple<int, int>> wirePoints = new List<Tuple<int, int>>();
            foreach (Tuple<char, int> move in wireMoves)
            {
                int x = node.Item1;
                int y = node.Item2;
                if (move.Item1 == 'U')
                {
                    wirePoints.AddRange(Enumerable.Range(1, move.Item2).Select(i => new Tuple<int, int>(x, y - i)));
                    y -= move.Item2;
                }
                if (move.Item1 == 'D')
                {
                    wirePoints.AddRange(Enumerable.Range(1, move.Item2).Select(i => new Tuple<int, int>(x, y + i)));
                    y += move.Item2;
                }
                if (move.Item1 == 'L')
                {
                    wirePoints.AddRange(Enumerable.Range(1, move.Item2).Select(i => new Tuple<int, int>(x - i, y)));
                    x -= move.Item2;
                }
                if (move.Item1 == 'R')
                {
                    wirePoints.AddRange(Enumerable.Range(1, move.Item2).Select(i => new Tuple<int, int>(x + i, y)));
                    x += move.Item2;
                }
                node = new Tuple<int, int>(x, y);
            }

            return wirePoints;
        }

        private static void Trace(Queue<Tuple<int, int>> pointsWireOne, char wire, int xmin, int ymin, char[,] grid, Queue<Tuple<int, int>> intersections)
        {
            Tuple<int, int> A = pointsWireOne.Dequeue();
            grid[A.Item2 + 1 - ymin, A.Item1 + 1 - xmin] = 'O';
            Tuple<int, int> B;
            while (pointsWireOne.Count > 0)
            {
                B = pointsWireOne.Dequeue();
                Line(grid, wire, A.Item1 + 1 - xmin, A.Item2 + 1 - ymin, B.Item1 + 1 - xmin, B.Item2 + 1 - ymin, intersections);
                A = B;
                if (pointsWireOne.Count > 0)
                    grid[A.Item2 + 1 - ymin, A.Item1 + 1 - xmin] = '+';
            }
        }

        private static Queue<Tuple<int, int>> GetPoints(List<Tuple<char, int>> wireMoves)
        {
            Tuple<int, int> node = new Tuple<int, int>(0, 0);
            Queue<Tuple<int, int>> wirePoints = new Queue<Tuple<int, int>>();
            wirePoints.Enqueue(node);
            foreach (Tuple<char, int> move in wireMoves)
            {
                int x = node.Item1;
                int y = node.Item2;
                if (move.Item1 == 'U')
                    y -= move.Item2;
                if (move.Item1 == 'D')
                    y += move.Item2;
                if (move.Item1 == 'L')
                    x -= move.Item2;
                if (move.Item1 == 'R')
                    x += move.Item2;
                node = new Tuple<int, int>(x, y);
                wirePoints.Enqueue(node);
            }

            return wirePoints;
        }

        private static void Display(char[,] grid, int width, int height)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    sb.Append(grid[y, x]);
                }
                sb.AppendLine();
            }
            File.WriteAllText("C:/Temp/DayThree.txt", sb.ToString());
        }

        private static void Line(char[,] grid, char wire, int x1, int y1, int x2, int y2, Queue<Tuple<int, int>> intersections)
        {
            if (x1 == x2)
            {
                if (y2 < y1)
                    (y1, y2) = (y2, y1);
                y1++;
                while (y1 < y2)
                {
                    if (grid[y1, x1] != ' ' && grid[y1, x1] != wire)
                        intersections.Enqueue(new Tuple<int, int>(x1, y1));
                    grid[y1, x1] = grid[y1, x1] == '.' ? wire : 'X';
                    y1++;
                }
            }
            else
            {
                if (x2 < x1)
                    (x1, x2) = (x2, x1);
                x1++;
                while (x1 < x2)
                {
                    if (grid[y1, x1] != ' ' && grid[y1, x1] != wire)
                        intersections.Enqueue(new Tuple<int, int>(x1, y1));
                    grid[y1, x1] = grid[y1, x1] == '.' ? wire : 'X';
                    x1++;
                }
            }
        }
    }
}
