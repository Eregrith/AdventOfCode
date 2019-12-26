using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class OffsetRelativeBaseEvent : IntcodeEvent
    {
        public OffsetRelativeBaseEvent(long addr, EventParam a) : base(addr)
        {
            Params.Add(a);
        }

        public override string ToString()
        {
            return $"r = r + {ParamLabel(0)}";
        }
    }
}
