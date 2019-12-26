using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class FinishEvent : IntcodeEvent
    {
        public FinishEvent(long addr) : base(addr)
        { }

        public override string ToString()
        {
            return $"stop";
        }
    }
}
