using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using static AdventOfCode2019.DayTen;
using static AdventOfCode2019.Program;

namespace AdventOfCode2019
{
    public class Panel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public Panel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }

    public static class DayEleven
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("11");
            List<Panel> panelsPainted = new List<Panel>();

            Intcode robot = new Intcode(data, IntcodeMode.Blocking | IntcodeMode.Quiet);
            Thread running = new Thread(() => robot.Run());
            running.Start();
            int x = 0;
            int y = 0;
            Direction facing = Direction.Up;
            while (!robot.IsFinished)
            {
                Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                if (panelAtXY == null)
                    robot.InputQueue.Enqueue(0);
                else
                    robot.InputQueue.Enqueue(panelAtXY.Color == Color.White ? 1 : 0);
                while (!robot.IsFinished && robot.OutputQueue.Count == 0) ;
                if (robot.IsFinished) break;
                long paint = robot.OutputQueue.Dequeue();
                if (paint == 1)
                {
                    if (panelAtXY != null)
                        panelAtXY.Color = Color.White;
                    else
                        panelsPainted.Add(new Panel(x, y, Color.White));
                }
                else
                {
                    if (panelAtXY != null)
                        panelAtXY.Color = Color.Black;
                    else
                        panelsPainted.Add(new Panel(x, y, Color.Black));
                }
                while (robot.OutputQueue.Count == 0) ;
                long action = robot.OutputQueue.Dequeue();
                if (action == 1)
                    facing = TurnRight(facing);
                else
                    facing = TurnLeft(facing);
                switch (facing)
                {
                    case Direction.Up:
                        y--;
                        break;
                    case Direction.Left:
                        x--;
                        break;
                    case Direction.Down:
                        y++;
                        break;
                    case Direction.Right:
                        x++;
                        break;
                }
            }
            Console.WriteLine("Robot finished painting !");
            for (y = panelsPainted.Min(p => p.Y); y < panelsPainted.Max(p => p.Y); y++)
            {
                for (x = panelsPainted.Min(p => p.X); x < panelsPainted.Max(p => p.X); x++)
                {
                    Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                    if (panelAtXY == null || panelAtXY.Color == Color.Black)
                        Console.Write('.');
                    else
                        Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{panelsPainted.Count} panels were painted !");
        }
        public static void PartTwo()
        {
            long[] data = InputHelper.GetIntcodeFromFile("11");
            List<Panel> panelsPainted = new List<Panel>();

            Intcode robot = new Intcode(data, IntcodeMode.Blocking | IntcodeMode.Quiet);
            Thread running = new Thread(() => robot.Run());
            running.Start();
            int x = 0;
            int y = 0;
            Direction facing = Direction.Up;
            while (!robot.IsFinished)
            {
                Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                if (panelAtXY == null)
                    robot.InputQueue.Enqueue(panelsPainted.Count == 0 ? 1 : 0);
                else
                    robot.InputQueue.Enqueue(panelAtXY.Color == Color.White ? 1 : 0);
                while (!robot.IsFinished && robot.OutputQueue.Count == 0) ;
                if (robot.IsFinished) break;
                long paint = robot.OutputQueue.Dequeue();
                if (paint == 1)
                {
                    if (panelAtXY != null)
                        panelAtXY.Color = Color.White;
                    else
                        panelsPainted.Add(new Panel(x, y, Color.White));
                }
                else
                {
                    if (panelAtXY != null)
                        panelAtXY.Color = Color.Black;
                    else
                        panelsPainted.Add(new Panel(x, y, Color.Black));
                }
                while (robot.OutputQueue.Count == 0) ;
                long action = robot.OutputQueue.Dequeue();
                if (action == 1)
                    facing = TurnRight(facing);
                else
                    facing = TurnLeft(facing);
                switch (facing)
                {
                    case Direction.Up:
                        y--;
                        break;
                    case Direction.Left:
                        x--;
                        break;
                    case Direction.Down:
                        y++;
                        break;
                    case Direction.Right:
                        x++;
                        break;
                }
            }
            Console.WriteLine("Robot finished painting !");
            for (y = panelsPainted.Min(p => p.Y); y <= panelsPainted.Max(p => p.Y); y++)
            {
                for (x = panelsPainted.Min(p => p.X); x <= panelsPainted.Max(p => p.X); x++)
                {
                    Panel panelAtXY = panelsPainted.FirstOrDefault(p => p.X == x && p.Y == y);
                    if (panelAtXY == null || panelAtXY.Color == Color.Black)
                        Console.Write('.');
                    else
                        Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{panelsPainted.Count} panels were painted !");
        }

        private static Direction TurnLeft(Direction facing)
        {
            switch (facing)
            {
                case Direction.Up:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Up;
            }
            return Direction.Up;
        }

        private static Direction TurnRight(Direction facing)
        {
            return TurnLeft(TurnLeft(TurnLeft(facing)));
        }
    }
}
