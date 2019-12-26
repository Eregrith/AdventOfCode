using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019.Intcode.Events
{
    public class WriteInputEvent : IntcodeEvent
    {
        public WriteInputEvent(long addr, EventParam a) : base(addr)
        {
            Params.Add(a);
        }

        public override string ToString()
        {
            return $"{ParamLabel(0)} = getInput()";
        }
    }
}
