using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Submarine
{
    public class ControlledSubmarine
    {
        public int HorizontalPosition { get; set; } = 0;
        public int Depth { get; set; } = 0;

        public void ApplyCommand(SubCommand command)
        {
            command.ApplyTo(this);
        }

        internal virtual void GoForward(int value)
        {
            HorizontalPosition += value;
        }

        internal virtual void GoDown(int value)
        {
            Depth += value;
        }

        internal virtual void GoUp(int value)
        {
            Depth -= value;
        }
    }
}
