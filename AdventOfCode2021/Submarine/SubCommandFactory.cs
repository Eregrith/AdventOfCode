using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Submarine
{
    public class SubCommandFactory
    {
        public SubCommand Parse(string line)
        {
            string[] parts = line.Split(' ');
            switch (parts[0])
            {
                case "forward":
                    return new ForwardCommand(int.Parse(parts[1]));
                case "down":
                    return new DownCommand(int.Parse(parts[1]));
                case "up":
                    return new UpCommand(int.Parse(parts[1]));
                default:
                    return new WrongCommand(line);
            }
        }
    }
}
