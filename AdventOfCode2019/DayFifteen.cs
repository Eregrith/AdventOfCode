using AdventOfCode2019.Intcode;
using AdventOfCode2019.Mazes;
using AdventOfCode2019.Mazes.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace AdventOfCode2019
{
    public static class DayFifteen
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("15");

            IntcodeComputer com = new IntcodeComputer(data, IntcodeMode.Blocking | IntcodeMode.Quiet);
            Thread bot = new Thread(() => com.Run());
            bot.Start();
            Maze maze = MakeMaze(com);
            Display(maze);
        }
        public static void PartTwo()
        {
            string input = InputHelper.GetInputFromFile("15_maze");

            Maze maze = new Maze(input.Split(Environment.NewLine).Select(l => l.ToArray()).ToArray(), new DayFifteenMazeFactory());

            int minutes = 0;
            while (maze.Cells.Any(c => c is MazeCorridor))
            {
                maze.PropagateOxygen();
                minutes++;
            }
            Console.WriteLine("Finished propagation of oxygen after " + minutes + " minutes");
        }

        private static void Display(Maze maze)
        {
            StringBuilder sb = new StringBuilder();
            for (int y = maze.MinY; y <= maze.MaxY; y++)
            {
                for (int x = maze.MinX; x <= maze.MaxX; x++)
                {
                    MazeCell cell = maze.CellAt(x, y);
                    sb.Append(cell == null ? '?' : cell.Display);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        private static Maze MakeMaze(IntcodeComputer com)
        {
            long output = -1;
            long input = 1;
            Point pos = new Point(0, 0);
            Maze m = new Maze();
            int iter = 0;
            m.AddStartAt(0, 0);
            while (iter < 100000)
            {
                Point left = Move(TurnLeft(input), pos);
                if (!(m.CellAt(left.X, left.Y) is MazeWall))
                    input = TurnLeft(input);
                com.InputQueue.Enqueue(input);
                while (com.OutputQueue.Count == 0);
                output = com.OutputQueue.Dequeue();
                switch (output)
                {
                    case 0:
                        AddWall(input, pos, m);
                        input = TurnRight(input);
                        break;
                    case 1:
                        pos = Move(input, pos);
                        AddCorridor(pos, m);
                        break;
                    case 2:
                        pos = Move(input, pos);
                        AddExit(pos, m);
                        break;
                }
                iter++;
            }
            return m;
        }

        private static void AddExit(Point pos, Maze m)
        {
            m.AddExitAt(pos.X, pos.Y);
        }

        private static long TurnLeft(long input)
        {
            return TurnRight(TurnRight(TurnRight(input)));
        }

        private static void AddCorridor(Point pos, Maze m)
        {
            m.AddCorridorAt(pos.X, pos.Y);
        }

        private static long TurnRight(long direction)
        {
            switch (direction)
            {
                case 1:
                    return 4;
                case 4:
                    return 2;
                case 2:
                    return 3;
                case 3:
                    return 1;
            }
            return 1;
        }

        private static void AddWall(long direction, Point pos, Maze m)
        {
            int x = pos.X;
            int y = pos.Y;
            switch (direction)
            {
                case 1:
                    y--;
                    break;
                case 2:
                    y++;
                    break;
                case 3:
                    x--;
                    break;
                case 4:
                    x++;
                    break;
            }
            m.AddWallAt(x, y);
        }

        private static Point Move(long direction, Point pos)
        {
            switch (direction)
            {
                case 1:
                    pos.Y--;
                    break;
                case 2:
                    pos.Y++;
                    break;
                case 3:
                    pos.X--;
                    break;
                case 4:
                    pos.X++;
                    break;
            }
            return pos;
        }
    }
}
