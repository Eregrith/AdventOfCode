using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class WriteOutputEvent : IntcodeEvent
    {
        public WriteOutputEvent(long addr, EventParam a) : base(addr)
        {
            Params.Add(a);
        }

        public override string ToString()
        {
            return $"Write({ParamLabel(0)})";
        }
    }
}
