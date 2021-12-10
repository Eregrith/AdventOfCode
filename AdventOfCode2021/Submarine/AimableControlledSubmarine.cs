using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Submarine
{
    public class AimableControlledSubmarine : ControlledSubmarine
    {
        public int Aim { get; set; }

        internal override void GoDown(int value)
        {
            Aim += value;
        }

        internal override void GoUp(int value)
        {
            Aim -= value;
        }

        internal override void GoForward(int value)
        {
            base.GoForward(value);
            Depth += Aim * value;
        }
    }
}
