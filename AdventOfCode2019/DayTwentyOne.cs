using AdventOfCode2019.Intcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public static class DayTwentyOne
    {
        public static void PartOne()
        {
            long[] data = InputHelper.GetIntcodeFromFile("21");
            IntcodeComputer com = new IntcodeComputer(data, IntcodeMode.Blocking | IntcodeMode.Quiet);
            List<string> commands = new List<string>();

            Console.WriteLine("Data ?");
            string line = "";
            while (line != "WALK")
            {
                line = Console.ReadLine();
                commands.Add(line + '\n');
            }
            foreach (string command in commands)
            {
                foreach (char c in command)
                    com.InputQueue.Enqueue(c);
            }
            com.Run();
            if (com.OutputQueue.Count > 1)
            {
                StringBuilder sb = new StringBuilder();
                while (com.OutputQueue.Count > 0)
                {
                    long output = com.OutputQueue.Dequeue();
                    sb.Append((char)output);
                }
                Console.WriteLine(sb.ToString());
            }
            else
                Console.WriteLine("Result : " + com.OutputQueue.Dequeue());
        }
    }
}
