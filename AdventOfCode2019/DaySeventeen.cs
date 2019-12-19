using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public static class DaySeventeen
    {
        public static void PartOne()
        {
            string lines = InputHelper.GetInputFromFile("17_maze");
            char[][] maze = lines.Split("\n").Select(l => l.ToCharArray()).ToArray();
            int sum = 0;
            for (int y = 0; y < maze.Length; y++)
            {
                for (int x = 0; x < maze[y].Length; x++)
                {
                    if (maze[y][x] == 'O')
                        sum += x * y;
                }
            }
            Console.WriteLine(sum);
        }

        public static void PartTwo()
        {
            List<string> commands = new List<string>
            {
                "A,B,B,A,C,B,C,C,B,A",
                "R,10,R,8,L,10,L,10",
                "R,8,L,6,L,6",
                "L,10,R,10,L,6",
                "n"
            };
            long[] data = InputHelper.GetIntcodeFromFile("17");
            IntcodeComputer com = new IntcodeComputer(data, IntcodeMode.Quiet);

            foreach (string command in commands)
            {
                foreach (char c in command.ToCharArray())
                {
                    com.InputQueue.Enqueue((long)c);
                }
                com.InputQueue.Enqueue(10);
            }
            com.Context.Data[0] = 2;

            com.Run();

            Console.WriteLine("Dust collected : " + com.OutputQueue.Dequeue());
        }
    }
}
