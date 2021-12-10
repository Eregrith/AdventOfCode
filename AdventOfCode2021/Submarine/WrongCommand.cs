using System;

namespace AdventOfCode2021.Submarine
{
    internal class WrongCommand : SubCommand
    {
        private readonly string _line;

        public WrongCommand(string line)
        {
            _line = line;
        }

        public override void ApplyTo(ControlledSubmarine sub)
        {
            Console.WriteLine($"Wrong command applied to sub : {_line}");
        }
    }
}